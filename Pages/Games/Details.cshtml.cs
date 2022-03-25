#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_ef_2022.Model;

namespace razor_ef_2022.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly GameStoreContext _context;
        private readonly ILogger<DetailsModel> _logger;

        public DetailsModel(ILogger<DetailsModel> logger, GameStoreContext context)
        {
            _context = context;
            _logger = logger;
        }

        public Game Game { get; set; }
        [BindProperty(Name = "curr_time", SupportsGet = true)]

        public DateTime TheDate { get; set; } = DateTime.MinValue;

        public string Qname { get; set; } = "Bobby";
        public string QueryValues { get; set; } = "";

        public async Task<IActionResult> OnGetAsync(int? id, string q_name)
        {
            if (id == null)
            {
                return NotFound();
            }

            foreach (var qp in Request.Query)
            {
                QueryValues += $"<div>{qp.Key}:{qp.Value}</div>";
            }


            _logger.Log(LogLevel.Information, "useless q_name:" + q_name);
            if (q_name != null)
            {
                Qname = q_name;
            }
            Game = await _context.Game.FirstOrDefaultAsync(m => m.GameId == id);

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
