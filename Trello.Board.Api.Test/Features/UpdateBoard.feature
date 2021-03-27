Feature: Update trello board

    
    @positive_cases
    Scenario Outline: Update board
        Given a pre existent board "Board to be updated"
        When a user execute a PUT requisition for a board with the parameters <name> <desc> <closed> <subscribed> <idOrganization> <prefs_permissionLevel> <prefs_voting> <prefs_comments> <prefs_invitations> <prefs_selfJoin> <prefs_cardCovers> <prefs_background> <prefs_cardAging> <prefs_calendarFeedEnabled> and <labelNames_green> to update the board
        Then a OK response status code response must be returned
        And a valid response body content

        Examples:
          | name              | desc               | closed | subscribed | idOrganization | prefs_permissionLevel | prefs_voting | prefs_comments | prefs_invitations | prefs_selfJoin | prefs_cardCovers | prefs_background | prefs_cardAging | prefs_calendarFeedEnabled | labelNames_green |
          | Public Board Test | Board updated test | true   | null       | null           | public                | public       | public         | admins            | false          | false            | pink             | pirate          | false                     | label            |