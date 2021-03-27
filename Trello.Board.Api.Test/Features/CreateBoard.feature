Feature: Create trello board

    Scenario Outline: Create board
        When a user execute a POST requisition with the parameters <name> <desc> <idOrganization> <idBoardSource> <keepFromSource> <powerUps> <defaultLabels> <defaultLists> <prefs_permissionLevel> <prefs_voting> <prefs_comments> <prefs_invitations> <prefs_selfJoin> <prefs_cardCovers> <prefs_background> and <prefs_cardAging> to create a board
        Then a status code response OK must be returned
        And a valid response body content must be returned

        Examples:
          | name               | desc                       | idOrganization | idBoardSource | keepFromSource | powerUps | defaultLabels | defaultLists | prefs_permissionLevel | prefs_voting | prefs_comments | prefs_invitations | prefs_selfJoin | prefs_cardCovers | prefs_background | prefs_cardAging |
          | Private Board Test | Private board created test | null           | null          | none           | all      | true          | true         | private               | disabled     | members        | members           | true           | true             | green            | regular         |