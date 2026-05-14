using System.Text.Json;
using JsonToSqlite.Common.DTOs;
using JsonToSqlite.Common.Models;
using JsonToSqlite.Sqlite;
using Microsoft.EntityFrameworkCore;

Console.WriteLine(args[0]);

await using var file = File.OpenRead(args[0]);
var json = await JsonSerializer.DeserializeAsync<YgoProDeckJson>(file);

using var db = new YugiohCardsDbContext();
await db.Database.MigrateAsync();

foreach (var card in json.Data)
{
    var password = card.Id.ToString().PadLeft(8, '0');

    db.Cards.Add(new YugiohCard
    {
        YgoProDeckId = card.Id,
        Password = password.Length == 8 ? password : null,
        Name = card.Name,
        Text = card.Text
    });
}

var changesMade = await db.SaveChangesAsync();

db.OptimizeForWeb();

Console.WriteLine($"Changes made: {changesMade.ToString("N0")}");
