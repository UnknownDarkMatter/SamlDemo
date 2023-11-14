using FileExchange.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExchange.Business.Interfaces;

public interface IFileService
{
    public Task<FileDto> CreateAsync(FileDto file, CancellationToken cancellationToken);
    public Task<IEnumerable<FileDto>> GetAllAsync(CancellationToken cancellationToken);
    public Task UpdateAsync(FileDto file, CancellationToken cancellationToken);
    public Task DeleteAsync(int id, CancellationToken cancellationToken);
}
