using System.Text.Json;

namespace Deals
{
    public partial class DealsApi
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

        //<summary>Method to get deals object</summary>
        //<returns>Returns APIResponse object</returns>  
        public APIResponse GetDeals(string format = "json")
        {
            APIResponse response = new APIResponse();
            if (format == "json")
            {
                return GetDealsJSON();
            }
            else
            {
                // Uncomment the below lines once the GetDealsXML() is implemented
                // return GetDealsXML();
            }
            return response;
        }

        //<summary>Method to serialize deals object to JSON.</summary>       
        //<returns>Returns JSON string</returns>      
        private APIResponse GetDealsJSON()
        {
            var json = JsonSerializer.Serialize(deals);
            return new APIResponse {
                ContentType = "application/json",
                Content = json
            };
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
