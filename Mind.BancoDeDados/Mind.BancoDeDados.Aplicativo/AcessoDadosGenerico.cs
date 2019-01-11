using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;

namespace Mind.BancoDeDados.Dominio
{
    public class AcessoDadosGenerico
    {
        private string connectionString;
        private DbProviderFactory factory;

        public AcessoDadosGenerico()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            this.factory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["conn"].ProviderName);
        }

        public void Inserir(Usuario usuario)
        {
            var connection = this.factory.CreateConnection();
            connection.ConnectionString = this.connectionString;
            var command = connection.CreateCommand();
            command.CommandText = "insert into usuario (nome, datanascimento) values (@nome, @dataNascimento)";

            var nome = command.CreateParameter();
            nome.ParameterName = "@nome";
            nome.Value = usuario.Nome;
            command.Parameters.Add(nome);

            var dataNascimento = command.CreateParameter();
            dataNascimento.ParameterName = "@dataNascimento";
            dataNascimento.Value = usuario.DataNascimento;
            command.Parameters.Add(dataNascimento);

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

        //public IList<Usuario> Ler()
        //{
        //    using (var connection = new SqlConnection(this.connectionString))
        //    {
        //        var command = new SqlCommand("select id, nome, datanascimento from usuario", connection);

        //        try
        //        {
        //            connection.Open();
        //            var reader = command.ExecuteReader();

        //            IList<Usuario> retorno = new List<Usuario>();
        //            while (reader.Read())
        //            {
        //                retorno.Add(new Usuario(reader.GetInt32(reader.GetOrdinal("id")), reader["nome"].ToString(), reader.GetDateTime(reader.GetOrdinal("dataNascimento"))));
        //            }
        //            return retorno;
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //}
    }
}
