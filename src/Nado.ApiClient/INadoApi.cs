using BS.Nado.ApiClient.Responses;
using Refit;

namespace BS.Nado.ApiClient;

public interface INadoApi
{
    [Get("/status")]
    Task<StatusResponse> Status(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/status_pool")]
    Task<StatusPoolResponse> StatusPool(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/get_account")]
    Task<GetAccountResponse> GetAccount(
        string address,
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/get_transaction")]
    Task<GetTransactionResponse> GetTransaction(
        string txid,
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/get_transactions_of_account")]
    Task<GetTransactionsOfAccountResponse> GetTransactionsOfAccount(
        string? address = null,
        string? batch = null,
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/get_block_number")]
    Task<GetBlockNumberResponse> GetBlockNumber(
        long number,
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/get_block")]
    Task<GetBlockResponse> GetBlock(
        string hash,
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/get_producer_set_from_hash")]
    Task<GetProducerSetFromHashResponse> GetProducerSetFromHash(
        string hash,
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/get_latest_block")]
    Task<GetLatestBlockResponse> GetLatestBlock(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/get_blocks_before")]
    Task<GetBlocksBeforeResponse> GetBlocksBefore(
        string hash,
        int count = 100,
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/get_blocks_after")]
    Task<GetBlocksAfterResponse> GetBlocksAfter(
        string hash,
        int count = 100,
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/transaction_pool")]
    Task<TransactionPoolResponse> TransactionPool(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/transaction_hash_pool")]
    Task<TransactionHashPoolResponse> TransactionHashPool(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/transaction_buffer")]
    Task<TransactionBufferResponse> TransactionBuffer(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/user_transaction_buffer")]
    Task<UserTransactionBufferResponse> UserTransactionBuffer(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/peers")]
    Task<PeersResponse> Peers(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/unreachable")]
    Task<UnreachableResponse> Unreachable(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/block_producers")]
    Task<BlockProducersResponse> BlockProducers(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/block_hash_pool")]
    Task<BlockHashPoolResponse> BlockHashPool(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/block_producers_hash_pool")]
    Task<BlockProducersHashPoolResponse> BlockProducersHashPool(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/penalties")]
    Task<PenaltiesResponse> Penalties(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/penalty")]
    Task<PenaltyResponse> Penalty(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/get_recommended_fee")]
    Task<GetRecommendedFeeResponse> GetRecommendedFee(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/submit_transaction")]
    Task<HttpResponseMessage> SubmitTransaction(
        string data,
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/trust_pool")]
    Task<GetTrustPoolResponse> GetTrustPool(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/announce_peer")]
    Task<string> AnnouncePeer(
        string ip,
        CancellationToken cancellationToken = default
    );

    [Get("/terminate")]
    Task<HttpResponseMessage> Terminate(
        string key,
        CancellationToken cancellationToken = default
    );

    [Get("/log")]
    Task<string> Log(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/whats_my_ip")]
    Task<string> WhatsMyIp(
        string? compress = null,
        CancellationToken cancellationToken = default
    );

    [Get("/force_sync_ip")]
    Task<string> ForceSyncIp(
        string ip,
        string key,
        CancellationToken cancellationToken = default
    );
}
