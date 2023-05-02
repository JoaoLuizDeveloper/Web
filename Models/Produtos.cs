using System.ComponentModel.DataAnnotations;
using Web.Enums;

namespace Web.Models
{
    public class Produtos
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string? NomeProduto { get; set; }
        public virtual double PrecoCusto { get; set; }
        public virtual double PrecoVenda { get; set; }
        public virtual int ProdutoTipo { get; set; } = 0;
        public virtual int Qtdproduto { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime? Updated { get; set; }
    }
}
