package com.cobenga.fileprocessor.dao;

import javax.annotation.Resource;
import javax.ejb.Stateless;
import javax.sql.DataSource;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Gabz18
 */
@Stateless
public class WordDaoImpl implements WordDao {

    private static final String EMPTY_TABLE_STATEMENT = "delete from fileprocessor.dictionary";

    private static final String CREATE_TABLE_STATEMENT = "CREATE TABLE fileprocessor.dictionary(\n" +
            "    word_id NUMBER GENERATED BY DEFAULT AS IDENTITY,\n" +
            "    word VARCHAR2(70) NOT NULL,\n" +
            "    PRIMARY KEY(word_id)\n" +
            ")";

    private static final String SELECT_TABLE_STATEMENT = "select count(*) from tab where tname = 'DICTIONARY'";

    private static final String INSERT_WORD_STATEMENT = "insert into fileprocessor.dictionary(word) values (?)";

    private static final String COUNT_WORD_STATEMENT = "SELECT COUNT(*) FROM fileprocessor.dictionary WHERE word LIKE ?";

    @Resource(lookup = "jdbc/oracledb")
    DataSource ds;

    /**
     * {@inheritDoc}
     */
    @Override
    public boolean wordExists(String word) {
        try (Connection conn = ds.getConnection();
             PreparedStatement stmt = conn.prepareStatement(COUNT_WORD_STATEMENT)) {
            stmt.setString(1, word);
            ResultSet r = stmt.executeQuery();
            r.next();
            int count = r.getInt("COUNT(*)");
            r.close();
            return count > 0;
        } catch (SQLException ex) {
            Logger.getLogger(WordDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false;
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public boolean insertWord(String word) {
        try (Connection conn = ds.getConnection();
             PreparedStatement stmt = conn.prepareStatement(INSERT_WORD_STATEMENT)) {
            stmt.setString(1, word);
            stmt.execute();
        } catch (SQLException ex) {
            Logger.getLogger(WordDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return true;
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public void reInitDb() {
        try {
            Connection conn = ds.getConnection();
            PreparedStatement stmt = conn.prepareStatement(SELECT_TABLE_STATEMENT);
            ResultSet r = stmt.executeQuery();
            r.next();
            int count = r.getInt("COUNT(*)");
            r.close();
            if (count < 1) {
                PreparedStatement stmt2 = conn.prepareStatement(CREATE_TABLE_STATEMENT);
                stmt2.execute();
            } else {
                PreparedStatement stmt1 = conn.prepareStatement(EMPTY_TABLE_STATEMENT);
                stmt1.execute();
            }

        } catch (SQLException e) {
            Logger.getLogger(WordDaoImpl.class.getName()).log(Level.SEVERE, null, e);
        }
    }
}
