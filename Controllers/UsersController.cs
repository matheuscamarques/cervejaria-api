using System.Collections.Generic;
using cervejaria_api.Modules.Users;
using cervejaria_api.Modules.Users.contracts;
using Microsoft.AspNetCore.Mvc;

namespace cervejaria_api.Controllers;
[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public List<IUsuario> Get()
    {
        return UsuarioServico.GetInstance().GetAll();
    }
    
    /**
     * Create a new administrator user
     */
    [HttpPost]
    public IActionResult Create([FromBody] Usuario usuario)
    {
        if (usuario == null)
        {
            return BadRequest();
        }
        int id = UsuarioServico.GetInstance().Create(usuario).Id;
        if(id == 0)
        {
            return BadRequest();
        }

        return Ok(new { id = id });
    }
    
}