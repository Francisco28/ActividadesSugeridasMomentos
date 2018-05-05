using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasMomentos.Models.ActividadesSugeridas
{
    public class eva_cat_actividades_sugeridas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdActividadSugerida { get; set; }

        public String Tema { get; set; }
        [RegularExpression(@"^[a-zA-Z.\s]+$", ErrorMessage = "Solo Letras Porfavor")]
        [Required(ErrorMessage = "Escriba una Descripcion a la actividad")]
        public String DesActividad { get; set; }

        public int IdTipoActividadSug { get; set; }

        [ForeignKey("IdTipoActividadSug")]
        public virtual eva_cat_tipo_actividades_sugeridas TipoActividadesSugeridas { get; set; }
    }
}
