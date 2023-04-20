using Microsoft.EntityFrameworkCore;
namespace UserInfo;

public class FanAppContext : DbContext{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string? oracleUser = Environment.GetEnvironmentVariable("ORACLE_APP_USER");
        string? oraclePassword = Environment.GetEnvironmentVariable("ORACLE_APP_PASSWORD");
        string dataSource = @"198.168.52.211:1521/pdbora19c.dawsoncollege.qc.ca";
        optionsBuilder.UseOracle($"User Id={oracleUser}; Password={oraclePassword}; Data Source={dataSource};");
    }

}