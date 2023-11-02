# language: nl

Feature: Calculator
Simple calculator for adding two numbers

    @mytag
    Scenario: Add two numbers
        Given the first number is 50
        And the second number is 70
        When the two numbers are added
        Then the result should be 120

    Scenario Outline:
        Given I have a house number <housenumber>
        When I send it to an API
        Then it will not be accepted

    Voorbeelden:
    | housenumber |
    | 0           |
    | -1          |
    
Voo