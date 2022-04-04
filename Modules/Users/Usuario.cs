using System;
using cervejaria_api.Modules.Users.contracts;

namespace cervejaria_api.Modules.Users;

public class Usuario : IUsuario
{
    public int Id { get; set; } = 0;
    public string? NomeUsuario { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public byte NivelAcesso { get; set; }
    public DateTime UptadedAt { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime DeletedAt { get; set; } 
}