using System.Text.Json.Serialization;

namespace BS.Nado.ApiClient.Responses;

public class PeerBufferResponse
{
    [JsonPropertyName("peer_buffer")]
    public List<string> PeerBuffer { get; set; } = new();
}
