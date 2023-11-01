using Xunit;
using static Deals.DealsApi;

namespace Deals
{
    public class DealsApiTests
    {
        [Fact]
        public void Test_GetDealsJSON_IsValid()
        {
            var dealsApi = new DealsApi();
            APIResponse response = dealsApi.GetDeals();
            Assert.Equal("application/json", response.ContentType);
        }

        [Fact]
        public void Test_GetDealsXML_IsValid()
        {
            var dealsApi = new DealsApi();
            APIResponse response = dealsApi.GetDeals("xml");
            Assert.Equal("application/xml", response.ContentType);
        }
    }
}
