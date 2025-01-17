Feature: Adding books to the bookstore

As a bookstore owner
I want to add new books to the catalog
So I can sell new books

Scenario: A bookstore owner, trying to add a new book without authorization
    Given a book with the title "David Copperfield" 
    And the author "Charles Dickens"
    And the isbn "9780140439441"
    When the bookstore owner adds a new book to the catalog
    Then the bookstore owner will get an error message

Scenario: A bookstore owner adding a new book to the catalog
    Given a book with the title "David Copperfield" 
    And the author "Charles Dickens"
    And the isbn "9780140439441"
    When the bookstore owner is logged in with the username "owner@test.com" and password "password123"
    And the bookstore owner adds a new book to the catalog
    Then the book is added to the catalog
    And the newly added book will be returned