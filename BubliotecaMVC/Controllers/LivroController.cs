using Microsoft.AspNetCore.Mvc;

namespace BubliotecaMVC.Controllers
{
    public class LivroController : Controller
    {
        public IActionResult Livro(string textoPesquisa) //precisa ser o mesmo nome da variavel q está na view
        {
            /*
            var listaDeLivros = new Livro("Primeiro Livro", "", new Autora("Fulana1"), 20.5, new string[] { });
            return View(listaDeLivros.ListaDeLivros);
            */

            Livro livro = new Livro();
            var listaDeLivros = livro.GetLivros(textoPesquisa);
            return View(listaDeLivros);
        }
        public IActionResult LivroDetail(int Id) //precisa ser o mesmo nome da variavel q está na view
        {
            var livro = new Livro().GetLivroPeloId(Id);
            return View(livro);
        }
    }
}
