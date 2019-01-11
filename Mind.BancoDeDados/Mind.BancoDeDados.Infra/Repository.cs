using System;
using System.Configuration;
using System.Data.Common;
using Mind.BancoDeDados.Infra.Builders;
using System.Collections.Generic;


namespace Mind.BancoDeDados.Infra
{
    public class Repository<T> where T : IEntity
    {
        private string connectionString;
        private DbProviderFactory factory;
        private IQueryBuilder<T> builder;

        public Repository(IQueryBuilder<T> builder)
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            this.factory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["conn"].ProviderName);
            this.builder = builder;
        }

        public void Inserir(T instance)
        {
            var connection = this.factory.CreateConnection();
            connection.ConnectionString = this.connectionString;
            var command = connection.CreateCommand();
            IDictionary<string, object> parametros = new Dictionary<string, object>();
            command.CommandText = this.builder.BuildInsert(instance, out parametros);

            foreach (var parametro in parametros)
            {
                var novoParametro = command.CreateParameter();
                novoParametro.ParameterName = parametro.Key;
                novoParametro.Value = parametro.Value;

                command.Parameters.Add(novoParametro);

            }

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
