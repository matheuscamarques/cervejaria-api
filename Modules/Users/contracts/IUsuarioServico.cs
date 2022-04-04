using System.Collections.Generic;

namespace cervejaria_api.Modules.Users.contracts;

public interface IUsuarioServico
{
    List<IUsuario> GetAll();
    IUsuario Create(IUsuario usuario);
}