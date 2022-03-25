using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razor_ef_2022.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty(SupportsGet = true, Name = "Query")]
    public string Query { get; set; }
    private readonly GameStoreContext _dbContext;


    public IndexModel(ILogger<IndexModel> logger, GameStoreContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public void OnGet()
    {
        _logger.Log(LogLevel.Critical, "Index was grt-ted");
    }
}
