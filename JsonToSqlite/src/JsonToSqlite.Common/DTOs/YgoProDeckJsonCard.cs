using System.Text.Json.Serialization;

namespace JsonToSqlite.Common.DTOs;

public sealed class YgoProDeckJsonCard
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("desc")]
    public string Text { get; init; }
}