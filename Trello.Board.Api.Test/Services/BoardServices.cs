using RestSharp;
using TrelloTests.Model;

namespace TrelloTests.Services
{
    public class BoardServices : BaseServices
    {
        public string CreateDefaultBoard(string name)
        {
            InitRequest("/boards/", Method.POST);
            Request.AddQueryParameter("name", name);
            var response = ExecuteRequest<BoardModel>().GetAwaiter().GetResult();
            return response.Data.Id;
        }

        public IRestResponse CreateBoard(string name, string desc, string idOrganization,
            string idBoardSource, string keepFromSource, string powerUps, string defaultLabels, string defaultLists,
            string prefs_permissionLevel, string prefs_voting, string prefs_comments, string prefs_invitations,
            string prefs_selfJoin, string prefs_cardCovers, string prefs_background, string prefs_cardAging)
        {
            InitRequest("/boards/", Method.POST);

            Request.AddQueryParameter("name", name)
                .AddParameter("desc", desc)
                .AddParameter("keepFromSource", keepFromSource)
                .AddParameter("powerUps", powerUps)
                .AddParameter("defaultLabels", defaultLabels)
                .AddParameter("defaultLists", defaultLists)
                .AddParameter("prefs_permissionLevel", prefs_permissionLevel)
                .AddParameter("prefs_voting", prefs_voting)
                .AddParameter("prefs_comments", prefs_comments)
                .AddParameter("prefs_invitations", prefs_invitations)
                .AddParameter("prefs_selfJoin", prefs_selfJoin)
                .AddParameter("prefs_cardCovers", prefs_cardCovers)
                .AddParameter("prefs_background", prefs_background)
                .AddParameter("prefs_cardAging", prefs_cardAging);

            if (idOrganization != "null" && idOrganization != "")
                Request.AddParameter("idOrganization", idOrganization);

            if (idBoardSource != "null" && idBoardSource != "")
                Request.AddParameter("idBoardSource", idBoardSource);

            return ExecuteRequest<BoardModel>().GetAwaiter().GetResult();
        }


        public IRestResponse UpdateBoard(string id, string name, string desc, string closed, string subscribed,
            string idOrganization, string prefs_permissionLevel, string prefs_voting, string prefs_comments, 
            string prefs_invitations, string prefs_selfJoin, string prefs_cardCovers, string prefs_background, 
            string prefs_cardAging, string prefs_calendarFeedEnabled, string labelNames_green)
        {
            InitRequest("/boards/" + id, Method.PUT);
            
            Request.AddQueryParameter("name", name)
                .AddParameter("desc", desc)
                .AddParameter("closed", closed)
                .AddParameter("prefs/permissionLevel", prefs_permissionLevel)
                .AddParameter("prefs/voting", prefs_voting)
                .AddParameter("prefs/comments", prefs_comments)
                .AddParameter("prefs/invitations", prefs_invitations)
                .AddParameter("prefs/selfJoin", prefs_selfJoin)
                .AddParameter("prefs/cardCovers", prefs_cardCovers)
                .AddParameter("prefs/background", prefs_background)
                .AddParameter("prefs/cardAging", prefs_cardAging)
                .AddParameter("prefs/calendarFeedEnabled", prefs_calendarFeedEnabled)
                .AddParameter("labelNames/green", labelNames_green);

            if (subscribed != "null" && subscribed != "")
                Request.AddParameter("subscribed", subscribed);

            if (idOrganization != "null" && idOrganization != "")
                Request.AddParameter("idOrganization", idOrganization);
            
            return ExecuteRequest<BoardModel>().GetAwaiter().GetResult();

        }

        public IRestResponse DeleteBoard(string id)
        {
            InitRequest("/boards/" + id, Method.DELETE);
            return ExecuteRequest<BoardModel>().GetAwaiter().GetResult();
        }

        public IRestResponse GetBoard(string id)
        {
            InitRequest("/boards/" + id, Method.GET);
            return ExecuteRequest<BoardModel>().GetAwaiter().GetResult();
        }
    }
}