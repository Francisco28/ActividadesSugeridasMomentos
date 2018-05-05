using ActividadesSugeridasMomentos.Models.ActividadesSugeridas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasMomentos.Models.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<eva_cat_tipo_actividades_sugeridas> TipoActividadesSugeridas { get; set; }

        public DbSet<eva_cat_actividades_sugeridas> ActividadesSugeridas { get; set; }

        public DbSet<eva_actividades_sug_estatus> ActividadesSugeridasEstatus { get; set; }

        public DbSet<cat_tipo_estatus> TiposEstatus { get; set; }
    }
}
