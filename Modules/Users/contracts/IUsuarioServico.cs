using System.Collections.Generic;

namespace cervejaria_api.Modules.Users.contracts;

public interface IUsuarioServico
{
    int[] GetAll();
    IUsuario Create(IUsuario usuario);
}