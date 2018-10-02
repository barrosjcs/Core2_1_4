using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap01.ViewComponents
{
    public class NoticiasViewComponent : ViewComponent
    {
        /// <summary>
        /// Método que invoca assincronamente uma consulta na base, seria análogo a uma User Control no Web Forms
        /// </summary>
        /// <param name="total"></param>
        /// <param name="noticiasUrgentes"></param>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync(int total, bool noticiasUrgentes)
        {
            var view = noticiasUrgentes ? "noticiasUrgentes" : "noticias";
            var itens = GetItems(total);

            return View(view, itens);
        }

        private IEnumerable<Noticia> GetItems(int total)
        {
            var retorno = new List<Noticia>();
            for (int i = 0; i < total; i++)
            {
                yield return new Noticia() { Id = i + 1, Titulo = $"Noticia sobre {i}" };
            }
        }
    }

    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Link { get; set; }
    }
}
