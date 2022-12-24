using System.Text.Json.Serialization;

namespace BS.Nado.ApiClient.Responses;

public class GetProducerSetFromHashResponse
{
    [JsonPropertyName("producer_set_hash")]
    public string ProducerSetHash { get; set; } = null!;

    [JsonPropertyName("producer_set")]
    public List<string> ProducerSet { get; set; } = new();
}
