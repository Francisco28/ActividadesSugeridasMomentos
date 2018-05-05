using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasMomentos.Models.ActividadesSugeridas
{
    public class eva_actividades_sug_estatus
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstatusDet { get; set; }

        [ForeignKey("IdTipoActividadSug")]
        public int IdTipoActividadSug { get; set; }
        //public String DesTipoActividadSugerida { get; set; }
        public virtual eva_cat_tipo_actividades_sugeridas TipoActividadesSugeridas { get; set; }

        [ForeignKey("IdActividadSugerida")]
        public int IdActividadSugerida { get; set; }
        //public String Tema { get; set; }
        public virtual eva_cat_actividades_sugeridas ActividadesSugeridas { get; set; }

        [ForeignKey("IdTipoEstatus")]
        public int IdTipoEstatus { get; set; }
        //public String Tema { get; set; }
        public virtual cat_tipo_estatus TiposEstatus { get; set; }

        public DateTime FechaEstatus { get; set; }

        public bool Actual { get; set; }
        public String Observacion { get; set; }

    }
}
