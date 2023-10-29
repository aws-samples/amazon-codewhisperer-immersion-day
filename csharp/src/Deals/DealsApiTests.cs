using Xunit;

namespace Deals
{
    public class DealsApiTests
    {
        [Fact]
        public void GetDealsJSONTest()
        {
            var dealsApi = new DealsApi();
            var json = dealsApi.GetDealsJSON();
            Assert.Equal("{\"Url\":\"https://example.com/deals/001\",\"Name\":\"Deal 001\",\"Description\":\"Deal 001 description\",\"Price\":\"100\",\"Currency\":\"USD\"},{\"Url\":\"https://example.com/deals/002\",\"Name\":\"Deal 002\",\"Description\":\"Deal 002 description\",\"Price\":\"200\",\"Currency\":\"USD\"},{\"Url\":\"https://example.com/deals/003\",\"Name\":\"Deal 003\",\"Description\":\"Deal 003 description\",\"Price\":\"300\",\"Currency\":\"USD\"}", json);
        }
    }
}
