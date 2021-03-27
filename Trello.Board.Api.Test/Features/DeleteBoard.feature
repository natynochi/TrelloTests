Feature: Delete trello board

    @positive_cases
    Scenario Outline: Delete trello board
        Given a existent board "Board to be deleted"
        When a user execute a DELETE requisition for a board 
        Then a response status code OK must be returned
        And the board must be NotFound anymore

     