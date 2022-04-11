using cervejaria_api.Infra.BodyInput;
using cervejaria_api.Modules.Users;
using Microsoft.AspNetCore.Mvc;

namespace cervejaria_api.Controllers;
[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public int[] Get()
    {
        return UsuarioServico.GetInstance().GetAll();
    }
    
    /**
     * Create a new administrator user
     */
    [HttpPost]
    public IActionResult Create([FromBody] UserCreateInput inputUsuario)
    {
        var usuario = new Usuario();
        usuario.NomeUsuario = inputUsuario.NomeUsuario;
        usuario.Senha = inputUsuario.senha;
        usuario.NivelAcesso = (byte)inputUsuario.NivelDeAcesso;
        
        int id = UsuarioServico.GetInstance().Create(usuario).Id;
        if(id == 0)
        {
            return BadRequest();
        }

        return Ok(new { id });
    }
    
}