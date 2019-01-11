using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mind.BancoDeDados.Dominio;

namespace Mind.BancoDeDados.Aplicativo
{
    class Program
    {
        static void Main(string[] args)
        {
            var acessoDados = new AcessoDadosGenerico();

            Usuario usuario = new Usuario("Virgílio", DateTime.Now);

            acessoDados.Inserir(usuario);

            //foreach (var usuario in acessoDados.Ler())
            //    Console.WriteLine(usuario.ToString());

            Console.ReadLine();
        }
    }
}
