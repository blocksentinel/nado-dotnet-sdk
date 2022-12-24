using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace BS.Nado.ApiClient.Responses;

public class TransactionHashPoolResponse
{
    [JsonPropertyName("transactions_hash_pool")]
    public Dictionary<string, string> TransactionHashPool { get; set; } = new();

    [JsonPropertyName("majority_transactions_hash_pool")]
    public string? MajorityTransactionsHashPool { get; set; }

    public class TransactionItem
    {
        public string Sender { get; set; } = null!;
        public string Recipient { get; set; } = null!;

        public long Amount { get; set; }
        public long Timestamp { get; set; }
        public JsonObject Data { get; set; } = null!;
        public string Nonce { get; set; } = null!;
        public long Fee { get; set; }

        [JsonPropertyName("public_key")]
        public string PublicKey { get; set; } = null!;

        public string TxId { get; set; } = null!;
        public string Signature { get; set; } = null!;
    }
}
