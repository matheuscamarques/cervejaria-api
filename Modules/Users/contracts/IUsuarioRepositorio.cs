using System.Collections;
using System.Collections.Generic;

namespace cervejaria_api.Modules.Users.contracts;

public interface IUsuarioRepositorio
{ 
    List<IUsuario> GetAll();
    IUsuario Create(IUsuario usuario);
}