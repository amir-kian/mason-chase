Feature: Customer
  In order to manage customer information
  As a system user
  I want to create a customer with valid data

  Scenario: Create customer with valid data
    Given I have entered the customer details
    When I create the customer
    Then the customer object should be created successfully
    And the customer details should be correct