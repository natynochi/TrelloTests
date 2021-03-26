Feature: Delete trello board

    @positive_cases
    Scenario Outline: Delete trello board
        Given a existent board 
        When a user execute a DELETE requisition for the board <id>
        Then a response status code 200 must be returned
        And the board must not exist anymore

        Examples:
          |id |
          | 1 |