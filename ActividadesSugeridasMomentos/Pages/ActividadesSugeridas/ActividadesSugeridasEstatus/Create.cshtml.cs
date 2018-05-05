using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActividadesSugeridasMomentos.Models.ActividadesSugeridas;
using ActividadesSugeridasMomentos.Models.Data;

namespace ActividadesSugeridasMomentos.Pages.ActividadesSugeridas.ActividadesSugeridasEstatus
{
    public class CreateModel : PageModel
    {
        private readonly ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext _context;

        public CreateModel(ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdActividadSugerida"] = new SelectList(_context.ActividadesSugeridas, "IdActividadSugerida", "DesActividad");
        ViewData["IdTipoActividadSug"] = new SelectList(_context.TipoActividadesSugeridas, "IdTipoActividadSug", "DesTipoActividadSug");
        ViewData["IdTipoEstatus"] = new SelectList(_context.TiposEstatus, "IdTipoEstatus", "IdTipoEstatus");
            return Page();
        }

        [BindProperty]
        public eva_actividades_sug_estatus eva_actividades_sug_estatus { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ActividadesSugeridasEstatus.Add(eva_actividades_sug_estatus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}