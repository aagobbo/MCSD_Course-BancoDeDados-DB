using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Mind.BancoDeDados.Dominio
{
    public class AcessoDados
    {
        private string connectionString;

        public AcessoDados()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        public void Inserir(Usuario usuario)
        {
            var connection = new SqlConnection(this.connectionString);
            var command = new SqlCommand("insert into usuario (nome, datanascimento) values (@nome, @dataNascimento)", connection);
            command.Parameters.AddWithValue("@nome", usuario.Nome);
            command.Parameters.AddWithValue("@dataNascimento", usuario.DataNascimento);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        public IList<Usuario> Ler()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = new SqlCommand("select id, nome, datanascimento from usuario", connection);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    IList<Usuario> retorno = new List<Usuario>();
                    while (reader.Read())
                    {
                        retorno.Add(new Usuario(reader.GetInt32(reader.GetOrdinal("id")), reader["nome"].ToString(), reader.GetDateTime(reader.GetOrdinal("dataNascimento"))));
                    }
                    return retorno;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
