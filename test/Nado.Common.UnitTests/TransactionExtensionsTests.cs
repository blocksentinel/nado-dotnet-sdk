using System.Text.Json.Nodes;
using BS.Nado.Common;
using Shouldly;

namespace Nado.Common.UnitTests;

public class TransactionExtensionsTests
{
    [Fact]
    public void ToMessageTx_should_return_message_transaction()
    {
        // Arrange
        RawTransaction rawTx = new()
        {
            Sender = "sender",
            Recipient = "recipient",
            Amount = 1,
            Timestamp = 1658473200,
            Data = new JsonObject(),
            Nonce = "nonce",
            Fee = 1,
            PublicKey = "publickey"
        };

        // Act
        MessageTransaction result = rawTx.ToMessageTx("test");

        // Assert
        result.TxId.ShouldBe("test");
        result.Sender.ShouldBe(rawTx.Sender);
        result.Recipient.ShouldBe(rawTx.Recipient);
        result.Amount.ShouldBe(rawTx.Amount);
        result.Timestamp.ShouldBe(rawTx.Timestamp);
        result.Data.ShouldBe(rawTx.Data);
        result.Nonce.ShouldBe(rawTx.Nonce);
        result.Fee.ShouldBe(rawTx.Fee);
        result.PublicKey.ShouldBe(rawTx.PublicKey);
    }

    [Fact]
    public void ToSignedTx_should_return_signed_transaction()
    {
        // Arrange
        MessageTransaction messageTx = new()
        {
            TxId = "test",
            Sender = "sender",
            Recipient = "recipient",
            Amount = 1,
            Timestamp = 1658473200,
            Data = new JsonObject(),
            Nonce = "nonce",
            Fee = 1,
            PublicKey = "publickey"
        };

        // Act
        SignedTransaction result = messageTx.ToSignedTx("signature");

        // Assert
        result.Signature.ShouldBe("signature");
        result.TxId.ShouldBe(messageTx.TxId);
        result.Sender.ShouldBe(messageTx.Sender);
        result.Recipient.ShouldBe(messageTx.Recipient);
        result.Amount.ShouldBe(messageTx.Amount);
        result.Timestamp.ShouldBe(messageTx.Timestamp);
        result.Data.ShouldBe(messageTx.Data);
        result.Nonce.ShouldBe(messageTx.Nonce);
        result.Fee.ShouldBe(messageTx.Fee);
        result.PublicKey.ShouldBe(messageTx.PublicKey);
    }
}
