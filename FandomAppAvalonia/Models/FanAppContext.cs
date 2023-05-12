using Microsoft.EntityFrameworkCore;
namespace UserInfo;

public class FanAppContext : DbContext{

    public virtual DbSet<User> USERS { get; set; } = null!;
    public virtual DbSet<Profile> PROFILES { get; set; } = null!;
    public virtual DbSet<Message> MESSAGES { get; set; } = null!;
    public virtual DbSet<Event> EVENTS { get; set; } = null!;
    public virtual DbSet<Category> CATEGORIES { get; set; } = null!;
    public virtual DbSet<Badge> BADGES { get; set; } = null!;
    public virtual DbSet<Fandom> FANDOMS { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        string? oracleUser = Environment.GetEnvironmentVariable("DBUSER");
        string? oraclePassword = Environment.GetEnvironmentVariable("DBPWD");
        string dataSource = @"198.168.52.211:1521/pdbora19c.dawsoncollege.qc.ca";
        optionsBuilder.UseOracle($"User Id={oracleUser}; Password={oraclePassword}; Data Source={dataSource};");
    }

}