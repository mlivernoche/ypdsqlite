using JsonToSqlite.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace JsonToSqlite.Sqlite;

public class YugiohCardsDbContext : DbContext
{
    public DbSet<YugiohCard> Cards { get; set; }

    public string DbPath { get; }

    public YugiohCardsDbContext()
    {
        DbPath = Path.Join(Environment.CurrentDirectory, "cards.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<YugiohCard>(static builder =>
        {
            builder.HasKey(static entity => entity.Name);
            builder.HasIndex(static entity => entity.Name);
            builder.HasIndex(static entity => entity.Password);
        });
    }

    public void OptimizeForWeb()
    {
        var connection = Database.GetDbConnection();
        connection.Open();
        using var command = connection.CreateCommand();

        // 1. Set Page Size to 4096 (better for Range Requests)
        // 2. Set Journal Mode to DELETE (Required for static hosting)
        // 3. VACUUM to defragment and shrink the file
        command.CommandText = @"
            PRAGMA page_size = 4096;
            PRAGMA journal_mode = DELETE;
            PRAGMA auto_vacuum = NONE;
            VACUUM;
            ANALYZE;";
        command.ExecuteNonQuery();
    }
}