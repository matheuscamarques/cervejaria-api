using System.Collections;

namespace cervejaria_api.Modules.Users.contracts;

public interface IUsuarioRepositorio
{ 
    List<IUsuario> GetAll();
    IUsuario Create(IUsuario usuario);
}