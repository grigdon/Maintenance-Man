namespace CarMaintenance.Api.Models
{
    public class Query
    {
        public string? Content { get; set; }
        
        // Constructors
        public Query() { }
        public Query(string content)
        {
            Content = content;
        }
    }
}