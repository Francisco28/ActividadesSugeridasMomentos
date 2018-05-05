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
    public class IndexModel : PageModel
    {
        private readonly ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext _context;

        public IndexModel(ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<eva_actividades_sug_estatus> eva_actividades_sug_estatus { get;set; }

        public async Task OnGetAsync()
        {
            eva_actividades_sug_estatus = await _context.ActividadesSugeridasEstatus
                .Include(e => e.ActividadesSugeridas)
                .Include(e => e.TipoActividadesSugeridas)
                .Include(e => e.TiposEstatus).ToListAsync();
        }
    }
}
