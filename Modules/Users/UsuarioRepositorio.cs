using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using cervejaria_api.Modules.Users.contracts;

namespace cervejaria_api.Modules.Users;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    public List<IUsuario> GetAll()
    {
        SqlConnection conn = AzureConn.GetConnection();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario", conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        List<IUsuario> usuarios = new List<IUsuario>();
        while (reader.Read())
        {
            IUsuario usuario = new Usuario();
            usuario.Id = Convert.ToInt32(reader["id"]);
            usuario.NomeUsuario = reader["nome_usuario"].ToString();
            usuario.CreateAt = Convert.ToDateTime(reader["created_at"]);
            usuario.UptadedAt = Convert.ToDateTime(reader["updated_at"]);
            usuarios.Add(usuario);
        }
        
        conn.Close();
        return usuarios;
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