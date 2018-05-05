using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasMomentos.Models.ActividadesSugeridas;
using ActividadesSugeridasMomentos.Models.Data;

namespace ActividadesSugeridasMomentos.Pages.ActividadesSugeridas
{
    public class DeleteModel : PageModel
    {
        private readonly ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext _context;

        public DeleteModel(ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_cat_actividades_sugeridas eva_cat_actividades_sugeridas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_cat_actividades_sugeridas = await _context.ActividadesSugeridas
                .Include(e => e.TipoActividadesSugeridas).SingleOrDefaultAsync(m => m.IdActividadSugerida == id);

            if (eva_cat_actividades_sugeridas == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_cat_actividades_sugeridas = await _context.ActividadesSugeridas.FindAsync(id);

            if (eva_cat_actividades_sugeridas != null)
            {
                _context.ActividadesSugeridas.Remove(eva_cat_actividades_sugeridas);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
