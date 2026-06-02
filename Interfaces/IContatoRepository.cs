using AgendaOnline.Models;

namespace AgendaOnline.Interfaces;

public interface IContatoRepository
{
    Task<List<Contato>> ObterTodos();
    Task<Contato?> ObterPorId(Guid id);
    Task Adicionar(Contato contato);
    Task Atualizar(Contato contato);
    Task Excluir(Guid id);
}