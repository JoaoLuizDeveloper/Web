namespace Web.Models
{
    public class Produtos
    {
        public virtual int Id { get; set; }
        public virtual string NomeProduto { get; set; }
        public virtual double PrecoCusto { get; set; }
        public virtual double PrecoVenda { get; set; }
        public virtual int ProdutoTipo { get; set; }
        public virtual int Qtdproduto { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Updated { get; set; }
    }
}
