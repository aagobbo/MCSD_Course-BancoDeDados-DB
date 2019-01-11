
using Mind.BancoDeDados.Infra.CustomAttributes;
using System;

namespace Mind.BancoDeDados.Dominio
{
    [Table("Usuario")]
    public class Usuario
    {
        [PrimaryKey("Id")]
        [Column("Id",ColumnType.Number,32)]
        public Int32 Id { get; }
        [Column("Nome",ColumnType.Text,50)]
        public string Nome { get; private set; }
        [Column("DataNascimento",ColumnType.DateTime,10)]
        public DateTime DataNascimento { get; private set; }

        public Usuario(Int32 id, string nome, DateTime dataNascimento) : this(nome, dataNascimento)
        {
            this.Id = id;
        }

        public Usuario(string nome, DateTime dataNascimento)
        {
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Nome: {1}, DataNascimento: {2}", this.Id, this.Nome, this.DataNascimento);
        }
    }
}
