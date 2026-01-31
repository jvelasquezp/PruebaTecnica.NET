using Microsoft.AspNetCore.Mvc;
using App2.Data;
using App2.Models;

namespace App2.Controllers
{
    public class MantenedorControllercs : Controller
    {
        Datos _datos = new Datos();
        public IActionResult Listar()
        {
            var listaTareas = _datos.ListarTareas();
            return View(listaTareas);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(TareaModel tarea)
        {
            if(!ModelState.IsValid)
                return View();
            var guardar = _datos.GuardarTarea(tarea);

            if(guardar)
            {
                return RedirectToAction("Listar");
            }
            else 
            { 
                return View();
            }
        }

        public IActionResult Editar(int IdTarea)
        {
            var tarea = _datos.ObtenerTarea(IdTarea);
            return View(tarea);
        }

        [HttpPost]
        public IActionResult Editar(TareaModel tarea)
        {
            if (!ModelState.IsValid)
                return View();
            var guardar = _datos.EditarTarea(tarea);

            if (guardar)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

    }
}
