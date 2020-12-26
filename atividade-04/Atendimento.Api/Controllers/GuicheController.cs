using System.Collections.Generic;
using System.Linq;
using Atendimento.Domain.Entities;
using Atendimento.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Atendimento.Domain.Controllers
{
  [ApiController]
  public class GuicheController : ControllerBase
  {
    private static GuicheController _guicheController;
    private readonly IList<Guiche> _listaGuiches;
    private readonly SenhaController _senhaController;

    public GuicheController()
    {
      if (_guicheController != null)
      {
        _listaGuiches = _guicheController._listaGuiches;
        _senhaController = _guicheController._senhaController;
      }
      else
      {
        _listaGuiches = new List<Guiche>();
        _senhaController = new SenhaController();
        _guicheController = this;
      }
    }

    [HttpPost]
    [Route("senha")]
    public Senha GerarSenha()
    {
      var senha = _senhaController.Gerar();

      return senha;
    }

    [HttpPost]
    [Route("guiche")]
    public IEnumerable<Guiche> Adicionar()
    {
      var guiche = new Guiche();

      _listaGuiches.Add(guiche);

      return _listaGuiches;
    }

    [HttpGet]
    [Route("guiche")]
    public IEnumerable<Guiche> Listar() =>
      _listaGuiches;

    [HttpGet]
    [Route("guiche/{guiche_id}")]
    public Guiche Buscar(int guiche_id)
    {
      var guicheEncontrado = _listaGuiches
        .FirstOrDefault(guice => guice.Id == guiche_id);

      return guicheEncontrado;
    }

    [HttpPut]
    [Route("guiche/{guiche_id}")]
    public Guiche Atualizar(int guiche_id)
    {
      var guicheEncontrado = _listaGuiches
        .FirstOrDefault(guice => guice.Id == guiche_id);

      if (guicheEncontrado == null)
        return null;

      guicheEncontrado.Chamar(_senhaController.FilaSenhas);

      return guicheEncontrado;
    }
  }
}