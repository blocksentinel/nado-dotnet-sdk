using BS.Nado.Common;

namespace Nado.Signer;

public interface ISigner
{
    Task<SignedTransaction> Sign(
        string privateKey,
        RawTransaction rawTx
    );
}
