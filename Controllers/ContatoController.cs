using AgendaOnline.Interfaces;
using AgendaOnline.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOnline.Controllers;

public class ContatoController : Controller
{
    private readonly IContatoService _contatoService;

    public ContatoController(IContatoService contatoService)
    {
        _contatoService = contatoService;
    }
    //Listar
    public async Task<IActionResult> Index(string pesquisa)
    {
        var contatos = await _contatoService.ObterTodos();

        if (!string.IsNullOrEmpty(pesquisa))
            contatos = contatos.Where(c=>c.Nome.Contains(pesquisa,StringComparison.OrdinalIgnoreCase)).ToList();

        return View(contatos);
    }

    //Tela Cadastro
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    //Cadastrar
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Contato contato)
    {
        if(!ModelState.IsValid) return View(contato);

        await _contatoService.Adicionar(contato);

        TempData["Sucesso"] = "Contato cadastrado com sucesso";

        return RedirectToAction(nameof(Index));
    }

    //Tela Edição
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var contato = await _contatoService.ObterPorId(id);
        if(contato is null) return NotFound();

        return View(contato);
    }

    //Editar
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Contato contato)
    {
        if(!ModelState.IsValid) return View(contato);

        await _contatoService.Atualizar(contato);

        TempData["Sucesso"] = "Contato Cadastrado";
        
        return RedirectToAction(nameof(Index));
    }

    //Tela Excluir
    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var contato = await _contatoService.ObterPorId(id);
        if(contato is null) return NotFound();
        return View(contato);
    }

    //Excluir
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ConfirmDelete(Guid id)
    {
        await _contatoService.Excluir(id);

        TempData["Sucesso"] = "Contato Removido";

        return RedirectToAction(nameof(Index));
    }
}