namespace TrelloTests.Model
{
    public class CreateBoard
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string DescData { get; set; }
        public bool Closed { get; set; }
        public string IdOrganization { get; set; }
        public string IdBoardSource { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public Prefs Prefs { get; set; }
        public LabelNames LabelNames { get; set; }
        public Limits Limits { get; set; }
        
        public string Type { get; set; }
        public bool DefaultLabels { get; set; }
        public string DefaultLists { get; set; }
        public string KeepFromSource { get; set; }
        public string PowerUps { get; set; }
    }
}