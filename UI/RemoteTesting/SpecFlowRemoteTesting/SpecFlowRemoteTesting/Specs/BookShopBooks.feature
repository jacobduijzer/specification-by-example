Feature: Bookshop Books

    Scenario: Searching books without result
        Given Jan, a software engineer, wants to buy new books about software development
        When he opens the bookshop's website
        And he searches for books about 'software developement'
        Then he will find no books he can buy

    Scenario: Searching books with result
        Given Kelly, a mother that wants to buy a book for her daughter
        When she opens the bookshop's website
        And she searches for books about 'the gruffalo'
        Then she will find books she can buy