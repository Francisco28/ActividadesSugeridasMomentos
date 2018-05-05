using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActividadesSugeridasMomentos.Models.ActividadesSugeridas;
using ActividadesSugeridasMomentos.Models.Data;
using ActividadesSugeridasMomentos.Models;

namespace ActividadesSugeridasMomentos.Pages.ActividadesSugeridas.ActividadesSugeridasEstatus
{
    public class CreateModel : PageModel
    {
        private readonly ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext _context;

        //Para sacar las listas de datos de las tablas
        //Tipos Actividades sugeridas y Actividades Sugeridas
        public IList<eva_cat_tipo_actividades_sugeridas> TipoActividadSugerida { get; set; }
        public IList<eva_cat_actividades_sugeridas> ActividadSugerida { get; set; }

        //Para Obtener el Id de la actividad
        public int IdActividad;
        public int IdTipo;
        public string DesActividad;
        public string DesTipo;
        public string username;
        public string idAct;
        public string idTipo;
        public string Tema;
        public string descripcion;
        public string tipo;
        public DateTime fecha;

        public CreateModel(ActividadesSugeridasMomentos.Models.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        //Se le pasa como parametro el id que viene en el @page del index
        [HttpGet("CreateChangeEvent/")]
        public IActionResult OnGet()
        {

            idAct = Request.Query["id"];
            idTipo = Request.Query["idtipo"];
            Tema = Request.Query["tema"].ToString();
            tipo = Request.Query["destipo"].ToString();
            descripcion = Request.Query["desact"].ToString();
            fecha = DateTime.Now;

            ViewData["IdActividadSugerida"] = idAct; // new SelectList(_context.ActividadesSugeridas, "IdActividadSugerida", "DesActividad");
            ViewData["IdTipoActividadSug"] = idTipo;// new SelectList(_context.TipoActividadesSugeridas, "IdTipoActividadSugerida", "DesTipoActividadSugerida");
            ViewData["IdTipoEstatus"] = new SelectList(_context.Set<cat_tipo_estatus>(), "IdTipoEstatus", "DesTipoEstatus");
            return Page();

           
        }

        [BindProperty]
        public eva_actividades_sug_estatus eva_actividades_sug_estatus { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ActividadesSugeridasEstatus.Add(eva_actividades_sug_estatus);
            await _context.SaveChangesAsync();

            idAct = Request.Query["id"];

            return RedirectToPage("./Index", new { id = idAct });
        }
    }
}