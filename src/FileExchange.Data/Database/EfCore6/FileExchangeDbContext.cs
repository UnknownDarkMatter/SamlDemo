using FileExchange.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExchange.Data.Database.EfCore6;

public class FileExchangeDbContext : DbContext
{
    public FileExchangeDbContext(DbContextOptions<FileExchangeDbContext> options) : base(options)
    {

    }
    public DbSet<FileDto> Files { get; set; }
}
