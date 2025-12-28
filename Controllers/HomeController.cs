using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniLink.Contracts; // Interface'imiz
using MiniLink.Data;      // Veritabanımız
using MiniLink.Models;    // Tablomuz

namespace MiniLink.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUrlShorteningService _urlService;
        private readonly AppDbContext _context;


        public HomeController(IUrlShorteningService urlService, AppDbContext context)
        {
            _urlService = urlService;
            _context = context;
        }

        public IActionResult Index()
        {
            var recentLinks = _context.ShortUrls
        .OrderByDescending(u => u.CreatedAt)
        .Take(10)
        .ToList();
            return View(recentLinks);
        }

        [HttpPost]
public async Task<IActionResult> Shorten(string originalUrl)
{

    if (string.IsNullOrEmpty(originalUrl))
    {
        ViewBag.Error = "Please enter a valid URL.";
        var emptyLinks = await _context.ShortUrls.OrderByDescending(u => u.CreatedAt).Take(10).ToListAsync();
        return View("Index", emptyLinks);
    }
    
    if (!originalUrl.StartsWith("http://") && !originalUrl.StartsWith("https://"))
    {
        originalUrl = "https://" + originalUrl;
    }

    var existingUrl = await _context.ShortUrls
        .FirstOrDefaultAsync(u => u.OriginalUrl == originalUrl);

    if (existingUrl != null)
    {
        ViewBag.ShortUrl = $"{Request.Scheme}://{Request.Host}/{existingUrl.Code}";
        
        var links = await _context.ShortUrls.OrderByDescending(u => u.CreatedAt).Take(10).ToListAsync();
        return View("Index", links);
    }

    var code = _urlService.GenerateUniqueCode();

    while (await _context.ShortUrls.AnyAsync(u => u.Code == code))
    {
        code = _urlService.GenerateUniqueCode();
    }

    var newUrl = new ShortUrl
    {
        OriginalUrl = originalUrl,
        Code = code,
        CreatedAt = DateTime.UtcNow,
        ClickCount = 0
    };

    _context.ShortUrls.Add(newUrl);
    await _context.SaveChangesAsync();
    
    ViewBag.ShortUrl = $"{Request.Scheme}://{Request.Host}/{code}";
    
    var recentLinks = await _context.ShortUrls
        .OrderByDescending(u => u.CreatedAt)
        .Take(10)
        .ToListAsync();

    return View("Index", recentLinks);
}

        [HttpGet("{code}")]
        public async Task<IActionResult> RedirectToUrl(string code)
        {
            var shortUrl = await _context.ShortUrls.FirstOrDefaultAsync(u => u.Code == code);

            if (shortUrl == null)
            {
                return NotFound();
            }

            shortUrl.ClickCount++;
            await _context.SaveChangesAsync();

            return Redirect(shortUrl.OriginalUrl);
        }

    }
}