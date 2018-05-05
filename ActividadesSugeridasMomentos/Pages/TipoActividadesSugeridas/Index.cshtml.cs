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
    public class IndexModel : PageModel
    {
        private readonly ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext _context;

        public IndexModel(ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<eva_cat_tipo_actividades_sugeridas> eva_cat_tipo_actividades_sugeridas { get;set; }

        public async Task OnGetAsync()
        {
            eva_cat_tipo_actividades_sugeridas = await _context.TipoActividadesSugeridas.ToListAsync();
        }
    }
}
