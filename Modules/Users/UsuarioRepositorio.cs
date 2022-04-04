using System.Data.SqlClient;
using System.Security.Cryptography;
using cervejaria_api.Modules.Users.contracts;

namespace cervejaria_api.Modules.Users;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    public List<IUsuario> GetAll()
    {
        List<IUsuario> users = new List<IUsuario>();
        Usuario karlaUser = new Usuario();
        karlaUser.Id = 0;
        karlaUser.NivelAcesso = 3;
        karlaUser.Senha = "123456";
        karlaUser.NomeUsuario = "karlinhaguerreiro";
        karlaUser.CreateAt = DateTime.Now;
        karlaUser.UptadedAt = DateTime.Now;
        users.Add(karlaUser);
        return users;
    }
    
    public IUsuario Create(IUsuario user)
    {
        SqlConnection conn = AzureConn.GetConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand(@"
        INSERT INTO [dbo].[usuario] (
                                        nivel_acesso,
                                        senha,
                                        nome_usuario) 
        OUTPUT INSERTED.id
        VALUES (
                @NivelAcesso,
                @Senha,
                @NomeUsuario)"
            , conn);
        
        cmd.Parameters.AddWithValue("@NivelAcesso", user.NivelAcesso);
        cmd.Parameters.AddWithValue("@Senha", user.Senha);
        cmd.Parameters.AddWithValue("@NomeUsuario", user.NomeUsuario);
        user.Id = (int)cmd.ExecuteScalar();
        conn.Close();
        
        return user;
    }
}