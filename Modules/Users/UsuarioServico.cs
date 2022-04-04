using System.Collections.Generic;
using cervejaria_api.Modules.Users.contracts;

namespace cervejaria_api.Modules.Users;

public class UsuarioServico : IUsuarioServico
{   
    // Implementação do Serviço
    private static IUsuarioRepositorio? _repository;
    public List<IUsuario> GetAll()
    {
        return _repository == null ? new List<IUsuario>() : _repository.GetAll();
    }

    public IUsuario Create(IUsuario usuario)
    {
        if(_repository == null)
            _repository = new UsuarioRepositorio();
        
        return _repository.Create(usuario);
    }
    
    // Implementação do Singleton
    private static UsuarioServico? _instance;
    private static readonly object Lock = new object();
    private UsuarioServico()
    {
        _repository = new UsuarioRepositorio();
    }
    
    public static UsuarioServico GetInstance()
    {
        if (_instance == null)
            lock (Lock)
                if (_instance == null)
                    _instance = new UsuarioServico();

        return _instance;
    }
    
}