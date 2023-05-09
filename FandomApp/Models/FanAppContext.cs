using Microsoft.EntityFrameworkCore;
namespace UserInfo;

public class FanAppContext : DbContext{

    public virtual DbSet<User> FandomUsers { get; set; } = null!;
    public virtual DbSet<Profile> FandomProfiles { get; set; } = null!;
    public virtual DbSet<Message> FandomMessages { get; set; } = null!;
    public virtual DbSet<Event> FandomEvents { get; set; } = null!;
    public virtual DbSet<UserMessage> FandomUserMessages { get; set; } = null!;
    public virtual DbSet<Fandom> Fandoms { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string? oracleUser = Environment.GetEnvironmentVariable("DBUSER");
        string? oraclePassword = Environment.GetEnvironmentVariable("DBPWD");
        string dataSource = @"198.168.52.211:1521/pdbora19c.dawsoncollege.qc.ca";
        optionsBuilder.UseOracle($"User Id={oracleUser}; Password={oraclePassword}; Data Source={dataSource};");
    }

}