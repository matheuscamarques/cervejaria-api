using System;

namespace cervejaria_api.Modules.Users.contracts;

public interface IUsuario
{
    int Id { get; set; }
    string? NomeUsuario { get; set; }
    String Senha { get; set; }
    byte NivelAcesso { get; set;}
    DateTime CreateAt { get; set; }
    DateTime UptadedAt { get; set; }
    DateTime DeletedAt { get; set; }
}