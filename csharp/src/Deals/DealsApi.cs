using System.Text.Json;

namespace Deals
{
    public class DealsApi
    {
        // List of Deals
        List<Deal> deals = new List<Deal>() {
            new Deal {
                Url = "https://example.com/deals/001",
                Name= "Deal 001",
                Description="Deal 001 description",
                Price= "100",
                Currency= "USD"},
            new Deal {
                Url = "https://example.com/deals/002",
                Name= "Deal 002",
                Description="Deal 002 description",
                Price= "200",
                Currency= "USD"},
            new Deal {
                Url = "https://example.com/deals/003",
                Name= "Deal 003",
                Description="Deal 003 description",
                Price= "300",
                Currency= "USD"}
        };

    
       //<summary>Method to serialize delas object to JSON.</summary>       
       //<returns>Returns JSON string</returns>      
        public string GetDealsJSON()
        {
            var json = JsonSerializer.Serialize(deals);
            return json;
        }
        
        // Deal model with all the properties
        public class Deal
        {
            public string Url { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public string Price { get; set; } = string.Empty;
            public string Currency { get; set; } = string.Empty;
        }
    }
}
