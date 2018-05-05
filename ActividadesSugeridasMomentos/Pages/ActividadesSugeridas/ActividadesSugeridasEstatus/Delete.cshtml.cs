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
    public class DeleteModel : PageModel
    {
        private readonly ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext _context;
        public int? idAct;

        public DeleteModel(ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_actividades_sug_estatus eva_actividades_sug_estatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            idAct = id;
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_actividades_sug_estatus = await _context.ActividadesSugeridasEstatus.FindAsync(id);

            if (eva_actividades_sug_estatus != null)
            {
                _context.ActividadesSugeridasEstatus.Remove(eva_actividades_sug_estatus);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id = idAct });
        }
    }
}
