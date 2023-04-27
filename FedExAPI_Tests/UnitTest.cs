namespace FedExAPI_Tests;

[TestClass]
public class UnitTests
{
    private string clientId = "";
    private string secretId = "";

    [TestMethod]
    public void Test_OAuth()
    {
        var client = new FedExAPI.FedExApiClient(clientId, secretId, true);

        var auth = client.RetrieveOAuth()
            .GetAwaiter().GetResult();

        Assert.IsNotNull(auth.Data);
        Assert.IsNull(auth.Error);
    }


}
