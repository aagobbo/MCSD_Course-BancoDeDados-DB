using System;

namespace Mind.BancoDeDados.Infra.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public string Nome { get; set; }

        public TableAttribute(string nome)
        {
            this.Nome = nome;
        }
    }
}
