namespace CarMaintenance.Api.Models
{
    public class Query
    {
        public string? Content { get; set; }
        
        public Query() { }
        public Query(string content)
        {
            Content = content;
        }
    }
}

