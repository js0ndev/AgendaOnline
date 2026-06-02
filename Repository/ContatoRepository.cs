using AgendaOnline.Data;
using AgendaOnline.Interfaces;
using AgendaOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaOnline.Repository;

public class ContatoRepository : IContatoRepository
{
    private readonly AppDbContext _context;
    
    public ContatoRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Contato>> ObterTodos()
    {
        return await _context.Contatos.ToListAsync();
    }
    public async Task<Contato?> ObterPorId(Guid id)
    {
        return await _context.Contatos.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task Adicionar(Contato contato)
    {
        await _context.Contatos.AddAsync(contato);
        await _context.SaveChangesAsync();
    }
    public async Task Atualizar(Contato contato)
    {
        _context.Contatos.Update(contato);
        await _context.SaveChangesAsync();
    }
    public async Task Excluir(Guid id)
    {
        var contato = await ObterPorId(id);
        if(contato is null) return;
        _context.Contatos.Remove(contato);
        await _context.SaveChangesAsync();
    }
}