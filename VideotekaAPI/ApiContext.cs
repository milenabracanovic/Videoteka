using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VideotekaAPI.Models;

namespace VideotekaAPI;

public class ApiContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ApiContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }
    public DbSet<Kupac> Kupci { get; set; }
    public DbSet<Film> Filmovi { get; set; }
    public DbSet<Zanr> Zanrovu { get; set; }
    public DbSet<TipClanstva> TipoviClanstva { get; set; }
    public DbSet<TipKupca> TipoviKupca { get; set; }
    public DbSet<Pozajmica> Pozajmicas { get; set; }
}