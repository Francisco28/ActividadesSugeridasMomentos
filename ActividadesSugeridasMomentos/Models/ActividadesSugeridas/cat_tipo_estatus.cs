using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace ActividadesSugeridasMomentos.Models.ActividadesSugeridas
{
    public class cat_tipo_estatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoEstatus { get; set; }
        public string DesTipoEstatus { get; set; }
    }
}
