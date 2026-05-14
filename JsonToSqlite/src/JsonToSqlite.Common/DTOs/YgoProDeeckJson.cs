using System.Text.Json.Serialization;

namespace JsonToSqlite.Common.DTOs;

public sealed class YgoProDeckJson
{
    [JsonPropertyName("data")]
    public IReadOnlyList<YgoProDeckJsonCard> Data { get; init; } = [];
}