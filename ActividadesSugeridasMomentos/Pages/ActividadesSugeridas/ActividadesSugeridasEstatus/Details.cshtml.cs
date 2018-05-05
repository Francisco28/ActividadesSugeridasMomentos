using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasMomentos.Models.ActividadesSugeridas;
using ActividadesSugeridasMomentos.Models.Data;

namespace ActividadesSugeridasMomentos.Pages.ActividadesSugeridas.ActividadesSugeridasEstatus
{
    public class DetailsModel : PageModel
    {
        private readonly ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext _context;
        public int? idAct;
        public int idacti;
        public DetailsModel(ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public eva_actividades_sug_estatus eva_actividades_sug_estatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            idAct = id;
            idacti = Convert.ToInt32(Request.Query["idacti"]);
            if (id == null)
            {
                return NotFound();
            }

            eva_actividades_sug_estatus = await _context.ActividadesSugeridasEstatus
                .Include(e => e.ActividadesSugeridas)
                .Include(e => e.TipoActividadesSugeridas)
                .Include(e => e.TiposEstatus).SingleOrDefaultAsync(m => m.IdEstatusDet == id);

            if (eva_actividades_sug_estatus == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
