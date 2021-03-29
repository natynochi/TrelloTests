Feature: Delete trello board

    Background:
        Given a user with trello access
        
    @positive_cases
    Scenario Outline: Delete board successfully
        Given a existent board <name>
        When the user delete the board <name>
        Then board should not be displayed in the home page anymore

        Examples:
          | name            |
          | Board to delete |