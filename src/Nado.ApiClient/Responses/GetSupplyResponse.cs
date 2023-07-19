using System.Text.Json.Serialization;

namespace BS.Nado.ApiClient.Responses;

public class GetSupplyResponse
{
    public long Produced { get; set; }
    public long Fees { get; set; }
    public long Burned { get; set; }

    [JsonPropertyName("block_number")]
    public long BlockNumber { get; set; }

    public long Reserve { get; set; }

    [JsonPropertyName("reserve_spent")]
    public long ReserveSpent { get; set; }

    public long Circulating { get; set; }

    [JsonPropertyName("total_supply")]
    public long TotalSupply { get; set; }
}
