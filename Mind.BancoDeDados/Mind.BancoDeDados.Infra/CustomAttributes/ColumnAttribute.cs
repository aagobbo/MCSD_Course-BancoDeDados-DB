using System;

namespace Mind.BancoDeDados.Infra.CustomAttributes
{
    public enum ColumnType
    {
        Text,
        Number,
        DateTime
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public ColumnType Type { get; set; }
        public int Length { get; set; }

        public ColumnAttribute(string name, ColumnType type)
        {
            this.Name = name;
            this.Type = type;
        }
        public ColumnAttribute(string name, ColumnType type, int lenght) : this(name, type)
        {
            this.Length = lenght;
        }
    }
}
