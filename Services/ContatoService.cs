using AgendaOnline.Data;
using AgendaOnline.Interfaces;
using AgendaOnline.Models;

namespace AgendaOnline.Services;

public class ContatoService : IContatoService
{
    private readonly IContatoRepository _repository;
    
    public ContatoService(IContatoRepository repository)
    {
        _repository = repository;
    }

     public async Task<List<Contato>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }
    public async Task<Contato?> ObterPorId(Guid id)
    {
        return await _repository.ObterPorId(id);
    }
    public async Task Adicionar(Contato contato)
    {
        await _repository.Adicionar(contato);
    }
    public async Task Atualizar(Contato contato)
    {
        await _repository.Atualizar(contato);
    }
    public async Task Excluir(Guid id)
    {
        await _repository.Excluir(id);
    }
}