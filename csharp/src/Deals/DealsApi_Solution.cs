using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

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

        //<summary>Method to serialize delas object to JSON.</summary>       
        //<returns>Returns JSON string</returns> 
        public string GetDealsJSON()
        {
            var json = JsonSerializer.Serialize(deals);
            return json;
        }

        #region
        // Create a method to convert Deals object to XML
        #endregion

        //<summary>Method to serialize deals object to XML</summary>       
        //<returns>Returns XML string</returns> 
        public string GetDealsXML()
        {
            var serializer = new XmlSerializer(typeof(List<Deal>));
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, deals);
                return sb.ToString();
            }
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
