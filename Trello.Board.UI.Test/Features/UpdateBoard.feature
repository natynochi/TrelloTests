Feature: Update trello board

    Background:
        Given a user with trello access

    @positive_cases
    Scenario Outline: Update board permission
        Given a existent board <name>
        When the user update the board <name> for <new_permission> 
        Then the board <name> <new_permission> must be seen in the board detail

        Examples:
          | name            | new_permission | 
          | Board to update | Public         | 