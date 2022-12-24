using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace BS.Nado.Common;

public class RawTransaction
{
    [JsonPropertyName("sender")]
    public string Sender { get; set; } = null!;

    [JsonPropertyName("recipient")]
    public string Recipient { get; set; } = null!;

    [JsonPropertyName("amount")]
    public long Amount { get; set; }

    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }

    [JsonPropertyName("data")]
    public JsonObject Data { get; set; } = null!;

    [JsonPropertyName("nonce")]
    public string Nonce { get; set; } = null!;

    [JsonPropertyName("fee")]
    public long Fee { get; set; }

    [JsonPropertyName("public_key")]
    public string PublicKey { get; set; } = null!;
}
