using Mind.BancoDeDados.Infra.CustomAttributes;
using System;

namespace Mind.BancoDeDados.Infra.Testes.Unit.Mocks
{
    [Table("Pessoa")]
    public class PessoaMock : IEntity
    {
        [PrimaryKey("PkPessoaId")]
        [Column("Id", ColumnType.Text)]
        public int Id { get; set; }
        [Column("Nome", ColumnType.Text, 50)]
        public string Nome { get; set; }
        [Column("DataNascimento", ColumnType.DateTime)]
        public DateTime DataNascimento { get; set; }
    }
}
