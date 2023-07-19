using System.Text;
using System.Text.Json;
using BS.Nado.Blake2Sharp;
using BS.Nado.Common;
using MessagePack;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Utilities.Encoders;

namespace Nado.Signer;

public class Signer : ISigner
{
    private readonly ILogger<Signer> _logger;
    private readonly JsonSerializerOptions _serializerOptions;

    public Signer(
        ILoggerFactory loggerFactory
    )
    {
        _logger = loggerFactory.CreateLogger<Signer>();
        _serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.General);
    }

    public Task<SignedTransaction> Sign(
        string privateKey,
        RawTransaction rawTx
    )
    {
        // Serialize raw transaction to create payload hash
        string serialized = JsonSerializer.Serialize(rawTx, _serializerOptions);
        string txId = Hash(serialized);

        // Transform to unsigned transaction
        MessageTransaction messageTx = rawTx.ToMessageTx(txId);
        _logger.LogTrace("Unsigned transaction: {@Tx}", messageTx);

        // Sign the transaction
        SignedTransaction signedTx = Sign(privateKey, messageTx);
        _logger.LogTrace("Signed transaction: {@Tx}", signedTx);

        return Task.FromResult(signedTx);
    }

    private static string Hash(
        string transaction
    )
    {
        byte[] bytes = Blake2B.ComputeHash(Encoding.UTF8.GetBytes(transaction), new Blake2BConfig { OutputSizeInBytes = 32 });

        return Convert.ToHexString(bytes).ToLowerInvariant();
    }

    private static SignedTransaction Sign(
        string privateKey,
        MessageTransaction messageTx
    )
    {
        Ed25519Signer signer = new();
        signer.Init(true, new Ed25519PrivateKeyParameters(Hex.DecodeStrict(privateKey)));
        byte[] packed = MessagePackSerializer.Serialize(messageTx);
        signer.BlockUpdate(packed);
        byte[]? bytes = signer.GenerateSignature();

        return messageTx.ToSignedTx(Convert.ToHexString(bytes).ToLowerInvariant());
    }
}
