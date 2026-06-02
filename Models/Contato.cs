using System.ComponentModel.DataAnnotations;

namespace AgendaOnline.Models;

public class Contato
{
    public Guid Id{get;set;} = Guid.NewGuid();

    [Required(ErrorMessage ="Nome é obrigatório!")]
    [StringLength(100)]
    public string Nome {get;set;} = string.Empty;

    [Required(ErrorMessage ="Telefone é obrigatório!")]
    [StringLength(11)]
    public string Telefone {get;set;} = string.Empty;

    [Required(ErrorMessage ="E-mail é obrigatório!")]
    [EmailAddress(ErrorMessage ="E-mail inválido")]
    public string Email {get;set;} = string.Empty;
}