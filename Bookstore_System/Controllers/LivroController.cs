using AutoMapper;
using Bookstore_System.Application.Interface;
using Bookstore_System.Domain.Entities;
using Bookstore_System.MVC.DataTransferObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;

namespace Bookstore_System.MVC.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroAppService _LivroAppService;

        public LivroController(ILivroAppService LivroAppService)
        {
            _LivroAppService = LivroAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string RetornaLivros()
        {
            return JsonConvert.SerializeObject(Mapper.Map<IEnumerable<LIVRO>, IEnumerable<LivroDataTransferObject>>(_LivroAppService.GetAll()));
        }

        [HttpPost]
        public string AdicionaLivro(string nome, string autor, string editora, string data_lancamento)
        {
            LivroDataTransferObject _livro = new LivroDataTransferObject();

            if(String.IsNullOrWhiteSpace(nome))
            {
                return JsonConvert.SerializeObject(CriaMensagem(500, "O campo nome está em branco!", String.Empty));
            }
            if (String.IsNullOrWhiteSpace(autor))
            {
                return JsonConvert.SerializeObject(CriaMensagem(500, "O campo autor está em branco!", String.Empty));
            }
            if (String.IsNullOrWhiteSpace(editora))
            {
                return JsonConvert.SerializeObject(CriaMensagem(500, "O campo editora está em branco!", String.Empty));
            }
            if (String.IsNullOrWhiteSpace(data_lancamento))
            {
                return JsonConvert.SerializeObject(CriaMensagem(500, "O campo data lancamento está em branco!", String.Empty));
            }

            _livro.nome = nome;
            _livro.autor = autor;
            _livro.editora = editora;
            _livro.data_lancamento = Convert.ToDateTime(data_lancamento);

            _LivroAppService.Add(Mapper.Map<LivroDataTransferObject, LIVRO>(_livro));

            return JsonConvert.SerializeObject(CriaMensagem(200, "Livro adicionado com sucesso!", String.Empty));
        }

        [HttpPost]
        public string EditaLivro(int id_livro, string nome, string autor, string editora, string data_lancamento)
        {
            LIVRO _livro = _LivroAppService.GetById(id_livro);

            if(_livro == null)
            {
                return JsonConvert.SerializeObject(CriaMensagem(500, "Livro inexistente!", String.Empty));
            }
            if (String.IsNullOrWhiteSpace(nome))
            {
                return JsonConvert.SerializeObject(CriaMensagem(500, "O campo nome está em branco!", String.Empty));
            }
            if (String.IsNullOrWhiteSpace(autor))
            {
                return JsonConvert.SerializeObject(CriaMensagem(500, "O campo autor está em branco!", String.Empty));
            }
            if (String.IsNullOrWhiteSpace(editora))
            {
                return JsonConvert.SerializeObject(CriaMensagem(500, "O campo editora está em branco!", String.Empty));
            }
            if (String.IsNullOrWhiteSpace(data_lancamento))
            {
                return JsonConvert.SerializeObject(CriaMensagem(500, "O campo data lancamento está em branco!", String.Empty));
            }

            _livro.NOME = nome;
            _livro.AUTOR = autor;
            _livro.EDITORA = editora;
            _livro.DATA_LANCAMENTO = Convert.ToDateTime(data_lancamento, CultureInfo.InvariantCulture);

            _LivroAppService.Update(_livro);

            return JsonConvert.SerializeObject(CriaMensagem(200, "Livro editado com sucesso!", String.Empty));
        }

        [HttpPost]
        public string RemoveLivro(int id_livro)
        {
            LIVRO _livro = _LivroAppService.GetById(id_livro);

            if(_livro == null)
            {
                return JsonConvert.SerializeObject(CriaMensagem(500, "Livro inexistente!", String.Empty));
            }

            _LivroAppService.Remove(_livro);

            return JsonConvert.SerializeObject(CriaMensagem(200, "Livro removido com sucesso!", String.Empty));
        }

        public Mensagem CriaMensagem(int codigo, string texto, string dado)
        {
            Mensagem m = new Mensagem();

            m.Codigo = codigo;
            m.Texto = texto;
            m.Dado = dado;

            return m;
        }
    }
}