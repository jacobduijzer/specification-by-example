Feature: Creating a new account

    Scenario: Entering an invalid email address 
        Given Jacob, a real bookworm, wants to register an account with Bruna
        When he opens the bookshop's website
        And goes to the login page
        And enters the email address 'jacob@somedomain.dev'
        Then he receives an error
        
    Scenario: Registering a new account
        Given Jacob, a real bookworm, wants to register an account with Bruna
        When he opens the bookshop's website
        And goes to the login page
        And enters the email address 'jacob@somedomain.com'
        Then he can enter the details of his new account