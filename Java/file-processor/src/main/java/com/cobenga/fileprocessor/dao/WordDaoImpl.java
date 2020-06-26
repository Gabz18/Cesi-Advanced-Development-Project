package com.cobenga.fileprocessor.dao;

import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

/**
 * @author Gabz18
 */
@Stateless
public class WordDaoImpl implements WordDao {

    @PersistenceContext(unitName = "frenchDictionary")
    private EntityManager em;

    /**
     * {@inheritDoc}
     */
    @Override
    public boolean wordExists(String word) {
        return !em.createNamedQuery("findWord").setParameter("word", "%" + word + "%").getResultList().isEmpty();
    }
}
