using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActividadesSugeridasMomentos.Models.ActividadesSugeridas;
using ActividadesSugeridasMomentos.Models.Data;

namespace ActividadesSugeridasMomentos.Pages.ActividadesSugeridas
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
        ViewData["IdTipoActividadSug"] = new SelectList(_context.TipoActividadesSugeridas, "IdTipoActividadSug", "DesTipoActividadSug");
            return Page();
        }

        [BindProperty]
        public eva_cat_actividades_sugeridas eva_cat_actividades_sugeridas { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ActividadesSugeridas.Add(eva_cat_actividades_sugeridas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}