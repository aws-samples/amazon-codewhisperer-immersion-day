using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using static Deals.DealsApi;

namespace Deals
{
    public class DealsApi_Solution
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
                response = GetDealsJSON();
            }
            else
            {                
                response = GetDealsXML();
            }
            return response;
        }

        //<summary>Method to serialize deals object to JSON.</summary>       
        //<returns>Returns JSON string</returns>      
        private APIResponse GetDealsJSON()
        {
            var json = JsonSerializer.Serialize(deals);
            return new APIResponse
            {
                ContentType = "application/json",
                Content = json
            };
        }

        #region
        // Create a method to convert Deals object to XML
        //<summary>Method to serialize deals object to XML.</summary>
        //<returns>Returns XML string</returns>
        private APIResponse GetDealsXML()
        {
            var serializer = new XmlSerializer(typeof(List<Deal>));
            var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, deals);
            return new APIResponse
            {
                ContentType = "application/xml",
                Content = stringWriter.ToString()
            };
        }

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
