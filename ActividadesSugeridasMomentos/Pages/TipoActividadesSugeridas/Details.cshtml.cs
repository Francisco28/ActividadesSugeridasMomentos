using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasMomentos.Models.ActividadesSugeridas;
using ActividadesSugeridasMomentos.Models.Data;

namespace ActividadesSugeridasMomentos.Pages.TipoActividadesSugeridas
{
    public class DetailsModel : PageModel
    {
        private readonly ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext _context;

        public DetailsModel(ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public eva_cat_tipo_actividades_sugeridas eva_cat_tipo_actividades_sugeridas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_cat_tipo_actividades_sugeridas = await _context.TipoActividadesSugeridas.SingleOrDefaultAsync(m => m.IdTipoActividadSug == id);

            if (eva_cat_tipo_actividades_sugeridas == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
