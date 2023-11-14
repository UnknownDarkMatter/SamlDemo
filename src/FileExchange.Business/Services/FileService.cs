using FileExchange.Business.Interfaces;
using FileExchange.Data.Database.Interfaces;
using FileExchange.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExchange.Business.Services;

public class FileService : IFileService
{
    public readonly IFileRepository _fileRepository;
    public FileService(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository ?? throw new ArgumentNullException(nameof(fileRepository));
    }

    public Task<FileDto> CreateAsync(FileDto file, CancellationToken cancellationToken)
    {
        return _fileRepository.CreateAsync(file, cancellationToken);
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        return _fileRepository.DeleteAsync(id, cancellationToken);
    }

    public Task<IEnumerable<FileDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _fileRepository.GetAllAsync(cancellationToken);
    }

    public Task UpdateAsync(FileDto file, CancellationToken cancellationToken)
    {
        return _fileRepository.UpdateAsync(file, cancellationToken);
    }
}
