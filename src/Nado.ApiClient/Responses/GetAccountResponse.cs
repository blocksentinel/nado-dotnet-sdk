namespace BS.Nado.ApiClient.Responses;

public class GetAccountResponse
{
    public string Address { get; set; } = null!;
    public long Balance { get; set; }
    public long Produced { get; set; }
    public long Burned { get; set; }
    public long Penalty { get; set; }
}
