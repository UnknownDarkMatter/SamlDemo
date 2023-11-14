using FileExchange.Data.Database.EfCore6;
using FileExchange.Data.Database.Interfaces;
using FileExchange.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExchange.Data.Database.Repositories;

public class FileRepository : IFileRepository
{
    private readonly FileExchangeDbContext _dbContext;
    public FileRepository(FileExchangeDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<FileDto> CreateAsync(FileDto file, CancellationToken cancellationToken)
    {
        _dbContext.Files.Add(file);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return file;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var file = _dbContext.Files.FirstOrDefault(m=>m.Id == id);
        if(file is null) { return; }

        _dbContext.Files.Remove(file);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<FileDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _dbContext.Files;
    }

    public async Task UpdateAsync(FileDto file, CancellationToken cancellationToken)
    {
        var entity = _dbContext.Files.FirstOrDefault(m => m.Id == file.Id);
        if (entity is null) { return; }

        entity.FriendlyName = file.FriendlyName;
        entity.HashedName = file.HashedName;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
