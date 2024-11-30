Feature: Banking Operations

  Scenario: Customer logs in and makes a deposit
    Given the customer navigates to the GlobalSQA Banking Project page
    When the customer logs in
    And the customer selects "Harry Potter" as their login name
    And the customer selects the "Deposit" tab
    And the customer enters an amount of "100" to deposit
    Then the system should display a successful deposit message

