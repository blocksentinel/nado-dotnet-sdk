using System.Text.Json.Serialization;

namespace BS.Nado.ApiClient.Responses;

public class TransactionHashPoolResponse
{
    [JsonPropertyName("transactions_hash_pool")]
    public Dictionary<string, string?> TransactionHashPool { get; set; } = new();

    [JsonPropertyName("majority_transactions_hash_pool")]
    public string? MajorityTransactionsHashPool { get; set; }
}
