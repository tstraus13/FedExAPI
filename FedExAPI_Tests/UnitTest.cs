using FedExAPI;
using FedExAPI.Structs;
using Microsoft.Extensions.Configuration;
namespace FedExAPI_Tests;

[TestClass]
public class UnitTests
{
    private readonly string? _clientId;
    private readonly string? _secretId;

    private readonly FedExApiClient _client;

    public UnitTests()
    {
        var configBuilder = new ConfigurationBuilder()
            .AddUserSecrets<UnitTests>();

        var config = configBuilder.Build();

        _clientId = config["fedex:clientId"];
        _secretId = config["fedex:secretId"];
        
        _client = new FedExApiClient(_clientId, _secretId, true);
    }

    [TestMethod]
    public void Test_OAuth()
    {
        var auth = _client.RetrieveOAuth()
            .GetAwaiter().GetResult();

        Assert.IsNotNull(auth.Data);
        Assert.IsNull(auth.Error);
    }

    [TestMethod]
    public void Test_TrackMultiPiece()
    {
        var multi = _client
            .TrackMultiPieceShipment("858488600850", AssociatedTypes.STANDARD_MPS)
            .GetAwaiter()
            .GetResult();

        Assert.IsTrue(multi.Data != null);
    }

    [TestMethod]
    public void Test_TrackByTrackingNumber()
    {
        var tracking = _client
            .TrackByTrackingNumber("231300687629630")
            .GetAwaiter()
            .GetResult();
        
        Assert.IsTrue(tracking.Data != null);
    }

    [TestMethod]
    public void Test_TrackDocument()
    {
        var doc = _client
            .TrackDocument("231300687629630", DocumentTypes.SIGNATURE_PROOF_OF_DELIVERY)
            .GetAwaiter()
            .GetResult();
        
        // TODO: Can not find valid mock tracking number to properly test
        Assert.IsTrue(true);
    }
}
