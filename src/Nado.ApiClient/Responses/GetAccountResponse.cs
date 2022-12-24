using System.Text.Json.Serialization;

namespace BS.Nado.ApiClient.Responses;

public class GetAccountResponse
{
    [JsonPropertyName("account_balance")]
    public long AccountBalance { get; set; }

    [JsonPropertyName("account_burned")]
    public long AccountBurned { get; set; }

    [JsonPropertyName("account_address")]
    public string AccountAddress { get; set; } = null!;

    [JsonPropertyName("account_produced")]
    public long AccountProduced { get; set; }
}
