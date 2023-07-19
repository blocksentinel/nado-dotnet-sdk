using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace BS.Nado.ApiClient.Responses;

public class TransactionPoolResponse
{
    [JsonPropertyName("transaction_pool")]
    public List<TransactionItem> TransactionPool { get; set; } = new();

    public class TransactionItem
    {
        public string Sender { get; set; } = null!;
        public string Recipient { get; set; } = null!;

        public long Amount { get; set; }
        public long Timestamp { get; set; }
        public JsonObject Data { get; set; } = null!;
        public string Nonce { get; set; } = null!;

        [JsonPropertyName("public_key")]
        public string PublicKey { get; set; } = null!;

        [JsonPropertyName("target_block")]
        public long TargetBlock { get; set; }

        public long Fee { get; set; }
        public string TxId { get; set; } = null!;
        public string Signature { get; set; } = null!;
    }
}
