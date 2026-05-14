namespace JsonToSqlite.Common.Models;

public sealed class YugiohCard
{
    public int YgoProDeckId { get; init; }
    public string? Password { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
}