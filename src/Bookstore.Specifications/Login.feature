Feature: Having the ability to login as store owner or as customer

Scenario: Login as store owner
    Given a store owner
    When the store owner logs in with the username "owner@test.nl" and password "password123"
    Then the store owner is logged in with the correct "BookstoreOwner" claim

Scenario: Login as customer
    Given a customer
    When the customer logs in with the username "customer@test.nl" and password "password123"
    Then the customer is logged in with the correct "Customer" claim