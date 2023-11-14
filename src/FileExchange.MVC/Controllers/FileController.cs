using FileExchange.Business.Interfaces;
using FileExchange.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileExchange.MVC.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;
    public FileController(IFileService fileService)
    {
        _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] FileDto file, CancellationToken cancellationToken)
    {
        file = await _fileService.CreateAsync(file, cancellationToken);
        return Ok(file);
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var files = await _fileService.GetAllAsync(cancellationToken);
        return Ok(files);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Update([FromBody] FileDto file, CancellationToken cancellationToken)
    {
        await _fileService.UpdateAsync(file, cancellationToken);
        return Ok();
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _fileService.DeleteAsync(id, cancellationToken);
        return Ok();
    }

}
