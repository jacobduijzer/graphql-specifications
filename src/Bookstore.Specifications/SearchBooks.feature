Feature: Searching for books

As an avid reader
I want to search for book information
So that I can find new books I want to read

    Scenario: Going through a list of books
        Given a customer, searching for books to buy
        When the customer request the full list of books
        Then the customer should find the following books:
          | Title                 | Author              |
          | The Great Gatsby      | F. Scott Fitzgerald |
          | 1984                  | George Orwell       |
          | To Kill a Mockingbird | Harper Lee          |

    Scenario: Searching books by title, getting stock information
        Given a customer, searching for books to buy
        When the customer is searching for books that contain "Great"
        Then the customer should find the following books:
          | Title            | Author              |
          | The Great Gatsby | F. Scott Fitzgerald |
        And the stock for this book should be 1