Feature: Browsing the IT&Care website

    Scenario: A developer, looking for a job
        Given Hans, a C# developer, is looking for a new job
        When he opens the website of IT&Care
        And he goes to the 'Vacatures' page
        Then he will be redirected to the IT&Care page on the 'Werken bij Human Total Care' website