using System.Text.Json.Nodes;
using MessagePack;

namespace BS.Nado.Common;

[MessagePackObject]
public class MessageTransaction
{
    [Key("sender")]
    public string Sender { get; init; } = null!;

    [Key("recipient")]
    public string Recipient { get; init; } = null!;

    [Key("amount")]
    public long Amount { get; init; }

    [Key("timestamp")]
    public long Timestamp { get; init; }

    [Key("data")]
    public JsonObject Data { get; init; } = null!;

    [Key("nonce")]
    public string Nonce { get; init; } = null!;

    [Key("fee")]
    public long Fee { get; init; }

    [Key("public_key")]
    public string PublicKey { get; init; } = null!;

    [Key("txid")]
    public string TxId { get; init; } = null!;
}
