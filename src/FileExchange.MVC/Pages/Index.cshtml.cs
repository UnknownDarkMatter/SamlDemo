using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace FileExchange.MVC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public string? MainJsWebPath = null;
        public string? MainCssWebPath = null;

        public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string jsPath = Path.Combine(webRootPath, "static/js");
            string cssPath = Path.Combine(webRootPath, "static/css");

            var jsRegex = new Regex("main\\..+\\.js");
            var cssRegex = new Regex("main\\..+\\.css");

            var jsFileInfo = (new DirectoryInfo(jsPath).GetFiles())
                .FirstOrDefault(f => jsRegex.IsMatch(f.Name));
            var cssFileInfo = (new DirectoryInfo(cssPath).GetFiles())
                .FirstOrDefault(f => cssRegex.IsMatch(f.Name));

            if (jsFileInfo != null)
            {
                MainJsWebPath = $"static/js/{jsFileInfo.Name}";
            }
            if (cssFileInfo != null)
            {
                MainCssWebPath = $"static/css/{cssFileInfo.Name}";
            }
            
        }
    }
}