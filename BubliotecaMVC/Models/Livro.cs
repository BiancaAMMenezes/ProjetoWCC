using BubliotecaMVC.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace BubliotecaMVC
{
    public class Livro
    {
        private string _titulo { get; set; }
        private string _descricao { get; set; }
        private double _preco { get; set; }
        private Autora _autora { get; set; }
        private string[] _genero { get; set; }
        [System.ComponentModel.Bindable(true)] //indica que o private titulo executa em tempo de execução
        private string _imagemURL { get; set; }
        private int _id { get; set; }

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        public Autora Autora
        {
            get { return _autora; }
            set { _autora = value; }
        }

        public double Preco
        {
            get { return _preco; }
            set { _preco = value; }
        }

        public string[] Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }

        public string ImagemURL
        {
            get { return _imagemURL; }
            set { _imagemURL = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        //_____________________________________________________
        //_______Construtor com e sem parametro________________
        //_____________________________________________________

        public Livro()
        {

        }

        public Livro( string titulo, string descricao, Autora autora, double preco, string[] genero)
        {
            _titulo = titulo;
            _descricao = descricao;
            _preco = preco;
            _autora = autora;
            _genero = genero;
        }

        public List<Livro> ListaDeLivros => new List<Livro>()
        {
            this,
            new Livro("Segundo Livro","",new Autora("Fulana 2"),30.5,new string[]{})
        };

        public List<Livro> GetLivros(string pesquisaLivro)
        {
            var servico = new BibliotecaService();
            var resposta = servico.BuscaLivros(pesquisaLivro);

            var listadeLivros = new List<Livro>();
            foreach (var item in resposta.Results)
            {
                var livro = new Livro()
                {
                    Id = item.trackid,
                    Titulo = item.trackName,
                    Autora = new Autora(item.artistName),
                    Preco = item.price,
                    Genero = item.genres,
                    Descricao = item.description,
                    ImagemURL = item.artworkUrl60
                };
                listadeLivros.Add(livro);
            }
            return listadeLivros;
        }
        public Livro GetLivroPeloId(int id)
        {
            var servico = new BibliotecaService();
            var resposta = servico.BuscaLivroPeloId(id);

            var livroResposta = resposta.Results[0];
            
            var livro = new Livro()
            {
                Id = livroResposta.trackid,
                Titulo = livroResposta.trackName,
                Autora = new Autora(livroResposta.artistName),
                Preco = livroResposta.price,
                Genero = livroResposta.genres,
                Descricao = Regex.Replace(livroResposta.description, "<[^>]*>", String.Empty),
                ImagemURL = livroResposta.artworkUrl60
            };
            return livro;
        }
    }
}
