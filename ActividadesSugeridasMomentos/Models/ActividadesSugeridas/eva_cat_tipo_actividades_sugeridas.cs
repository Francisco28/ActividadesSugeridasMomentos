using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadesSugeridasMomentos.Models.ActividadesSugeridas
{
    public class eva_cat_tipo_actividades_sugeridas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoActividadSug { get; set; }
        [RegularExpression(@"^[a-zA-Z.\s]+$", ErrorMessage = "Solo Letras Porfavor")]
        [Required(ErrorMessage = "Escriba una Descripcion a la actividad")]
        public String DesTipoActividadSug { get; set; }
    }
}
