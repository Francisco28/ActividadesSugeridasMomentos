using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasMomentos.Models.ActividadesSugeridas;
using ActividadesSugeridasMomentos.Models.Data;

namespace ActividadesSugeridasMomentos.Pages.ActividadesSugeridas
{
    public class EditModel : PageModel
    {
        private readonly ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext _context;

        public EditModel(ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext context)
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
           ViewData["IdTipoActividadSug"] = new SelectList(_context.TipoActividadesSugeridas, "IdTipoActividadSug", "DesTipoActividadSug");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(eva_cat_actividades_sugeridas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_cat_actividades_sugeridasExists(eva_cat_actividades_sugeridas.IdActividadSugerida))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool eva_cat_actividades_sugeridasExists(int id)
        {
            return _context.ActividadesSugeridas.Any(e => e.IdActividadSugerida == id);
        }
    }
}
