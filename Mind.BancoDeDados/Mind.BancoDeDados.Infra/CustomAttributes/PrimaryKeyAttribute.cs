using System;
using System.Collections.Generic;
using System.Text;

namespace Mind.BancoDeDados.Infra.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {
        public string Name { get; set; }

        public PrimaryKeyAttribute(string name)
        {
            this.Name = name;
        }
    }
}
