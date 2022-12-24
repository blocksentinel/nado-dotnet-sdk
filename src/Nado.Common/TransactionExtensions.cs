﻿namespace BS.Nado.Common;

public static class TransactionExtensions
{
    public static MessageTransaction ToMessageTx(
        this RawTransaction input,
        string txId
    )
    {
        return new MessageTransaction
        {
            TxId = txId,
            Sender = input.Sender,
            Recipient = input.Recipient,
            Amount = input.Amount,
            Timestamp = input.Timestamp,
            Data = input.Data,
            Nonce = input.Nonce,
            Fee = input.Fee,
            PublicKey = input.PublicKey
        };
    }

    public static SignedTransaction ToSignedTx(
        this MessageTransaction input,
        string signature
    )
    {
        return new SignedTransaction
        {
            TxId = input.TxId,
            Sender = input.Sender,
            Recipient = input.Recipient,
            Amount = input.Amount,
            Timestamp = input.Timestamp,
            Data = input.Data,
            Nonce = input.Nonce,
            Fee = input.Fee,
            PublicKey = input.PublicKey,
            Signature = signature
        };
    }
}
