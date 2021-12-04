using Microsoft.AspNetCore.Mvc;

namespace BibliotecaMVC.Controllers
{
    public class LivroController : Controller
    {
        public IActionResult Livro(string textoPesquisa)
        {

            Livro livro = new Livro();
            var listaDeLivros = livro.GetLivros(textoPesquisa);
            return View(listaDeLivros);
        }
        public IActionResult LivroDetail(int Id)
        {
            var livro = new Livro().GetLivroPeloId(Id);
            return View(livro);
        }
    }
}
