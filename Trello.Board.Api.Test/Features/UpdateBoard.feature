Feature: Update trello board

    @positive_cases
    Scenario Outline: Update board
        Given a existent board
        When a user execute a PUT requisition for the board <id> with the parameters <name>, <desc>, <closed>, <subscribed>, <idOrganization>, <prefs_permissionLevel>, <prefs_voting>, <prefs_comments>, <prefs_invitations>, <prefs_selfJoin>, <prefs_cardCovers>, <prefs_background>, <prefs_cardAging>, <prefs_calendarFeedEnabled>, <labelNames_green>, <labelNames_yellow>, <labelNames_orange>, <labelNames_red>, <labelNames_purple> and <labelNames_blue> to update the board
        Then a 200 response status code must be returned
        And a valid response body content

        Examples:
          |id |name               | desc                      |closed |subscribed |idOrganization | prefs_permissionLevel |prefs_voting |prefs_comments |prefs_invitations |prefs_selfJoin |prefs_cardCovers |prefs_background |prefs_cardAging |prefs_calendarFeedEnabled |labelNames_green |labelNames_yellow |labelNames_orange |labelNames_red |labelNames_purple |labelNames_blue |
          |   | Public Board Test | Public board created test | true  |           |               |public                 | public      | public        | admin            | false         | false           | pink            | pirate         | false                    |                 |                  |                  |               |                  |                |