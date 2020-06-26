package com.cobenga.fileprocessor.dao;

import javax.persistence.*;

@Entity
@NamedQuery(
        name = "findWord",
        query = "SELECT w FROM FrenchWord WHERE w.word LIKE :word"
)
public class FrenchWord {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @Column(name = "word")
    private String word;

    public FrenchWord() {
    }

    public FrenchWord(String word) {
        this.word = word;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getWord() {
        return word;
    }

    public void setWord(String word) {
        this.word = word;
    }
}
