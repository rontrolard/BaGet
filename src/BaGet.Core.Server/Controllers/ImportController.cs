using System.Threading;
using System.Threading.Tasks;
using BaGet.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaGet.Controllers
{
    public class ImportController : Controller
    {
        private IPackageDownloadsSource _source;
        private IContext _context;
        private ILogger<DownloadsImporter> _logger;
        public ImportController(IPackageDownloadsSource source, IContext context, ILogger<DownloadsImporter> logger)
        {
            _source = source;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var di=new DownloadsImporter(_context, _source, _logger);
            var token=new CancellationToken();
            await di.ImportAsync(token);
            return Ok();
        }
    }
}
