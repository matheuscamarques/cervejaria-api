using System.ComponentModel.DataAnnotations;

namespace cervejaria_api.Infra.BodyInput;

public class UserCreateInput 
{
    public enum LevelAcess
    {
        Pcp = 1,
        Rh,
        Admin
    }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public String NomeUsuario {get; set;} = "" ;
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public String senha {get;set;}
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public LevelAcess NivelDeAcesso {get;set;}
}