using Microsoft.AspNetCore.Mvc;
using SistemaNotas.Models;

namespace SistemaNotas.Controllers
{
    public class NotasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calcular(NotasModel notas)
        {
            ModelState.Clear();

            if (validar(notas)) notas.CalcularMedia();

            return View("Index", notas);
        }

        private bool validar(NotasModel nota)
        {
            bool valid = true;
            if (testeErro(nota.Nota1, "Nota1")) valid = false;
            if (testeErro(nota.Nota2, "Nota2")) valid = false;
            return valid;
        }

        private bool testeErro(float? nota, string name)
        {
            bool valid = false;
            if (nota is null)
            {
                ModelState.AddModelError(name, "Insira uma nota válida");
                valid = true;
            }
            
            if (nota < 0 || nota > 10)
            {
                ModelState.AddModelError(name, "O valor deve estar compreendido entre 0 e 10");
                valid = true;
            }
            return valid;
        }
    }
}
