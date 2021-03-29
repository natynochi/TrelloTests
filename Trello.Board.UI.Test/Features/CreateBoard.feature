Feature: Create trello board

    Background:
        Given a user with trello access
    
    @positive_cases
    Scenario Outline: Create board successfully
        When the user create a board <name> with the permission level <permission> and <color>
        Then the new board <name> area must be seen with the <permission> and <colorRGB>

        Examples:
          | name           | permission | color | colorRGB             |
          | New Board Test | Private    | green | rgba(81, 152, 57, 1) |