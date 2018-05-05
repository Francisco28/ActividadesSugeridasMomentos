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

namespace ActividadesSugeridasMomentos.Pages.ActividadesSugeridas.ActividadesSugeridasEstatus
{
    public class EditModel : PageModel
    {
        private readonly ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext _context;

        public EditModel(ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_actividades_sug_estatus eva_actividades_sug_estatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
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
           ViewData["IdActividadSugerida"] = new SelectList(_context.ActividadesSugeridas, "IdActividadSugerida", "DesActividad");
           ViewData["IdTipoActividadSug"] = new SelectList(_context.TipoActividadesSugeridas, "IdTipoActividadSug", "DesTipoActividadSug");
           ViewData["IdTipoEstatus"] = new SelectList(_context.TiposEstatus, "IdTipoEstatus", "IdTipoEstatus");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(eva_actividades_sug_estatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_actividades_sug_estatusExists(eva_actividades_sug_estatus.IdEstatusDet))
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

        private bool eva_actividades_sug_estatusExists(int id)
        {
            return _context.ActividadesSugeridasEstatus.Any(e => e.IdEstatusDet == id);
        }
    }
}
