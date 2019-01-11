using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mind.BancoDeDados.Infra.Builders;
using Mind.BancoDeDados.Infra.Testes.Unit.Mocks;
using System;
using System.Collections.Generic;

namespace Mind.BancoDeDados.Infra.Testes.Unit
{
    [TestClass]
    public class SQLServerBuilderSpec
    {
        [TestMethod]
        public void DeveGerarScriptSelecao()
        {
            //Arrange
            var builder = new SQLServerBuilder<PessoaMock>();

            //Act
            var select = builder.BuildSelect();

            //Assert
            Assert.AreEqual("select id, nome, datanascimento from pessoa", select.ToLower());
        }

        [TestMethod]
        public void DeveGerarScriptInsert()
        {
            //Arrange
            var builder = new SQLServerBuilder<PessoaMock>();
            var pessoa = new PessoaMock() { Id = 1, Nome = "João", DataNascimento = new DateTime(2000,01,01) };
            IDictionary<string, object> parametros = new Dictionary<string, object>();
            
            //Act
            var insert = builder.BuildInsert(pessoa, out parametros);

            //Assert
            Assert.AreEqual(@"insert into pessoa values(1, 'João', '2000-01-01'", insert.ToLower());
        }
    }
}
