using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadesSugeridasMomentos.Models.ActividadesSugeridas;
using ActividadesSugeridasMomentos.Models.Data;
using ActividadesSugeridasMomentos.Models;

namespace ActividadesSugeridasMomentos.Pages.ActividadesSugeridas.ActividadesSugeridasEstatus
{
    public class IndexModel : PageModel
    {
        private readonly ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext _context;

        public IndexModel(ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<eva_actividades_sug_estatus> ActividadSugeridaEstatus { get; set; }
        public IList<eva_cat_tipo_actividades_sugeridas> TipoActividadSugerida { get; set; }
        public IList<eva_cat_actividades_sugeridas> ActividadSugerida { get; set; }


        public string message;
        public string description;
        public string tipo;
        public int Tipos;
        public int IdDescripcion;
        public int IdActividad;

        public async Task OnGetAsync(int id)
        {
            ActividadSugeridaEstatus = await _context.ActividadesSugeridasEstatus
                .Include(a => a.ActividadesSugeridas)
                .Include(a => a.TipoActividadesSugeridas)
                .Include(a => a.TiposEstatus).ToListAsync();

            ActividadSugerida = await _context.ActividadesSugeridas
                .Include(a => a.TipoActividadesSugeridas).ToListAsync();

            TipoActividadSugerida = await _context.TipoActividadesSugeridas.ToListAsync();


            IdActividad = id;


            foreach (var value in ActividadSugerida)
            {
                if (id == value.IdActividadSugerida)
                {
                    message = value.Tema.ToString();
                    description = value.DesActividad.ToString();
                    IdDescripcion = value.IdTipoActividadSug;

                    foreach (var val in TipoActividadSugerida)
                    {
                        if (IdDescripcion == val.IdTipoActividadSug)
                        {
                            tipo = val.DesTipoActividadSug.ToString();
                            Tipos = val.IdTipoActividadSug;
                        }
                    }

                }


            }
        }


    }
}
