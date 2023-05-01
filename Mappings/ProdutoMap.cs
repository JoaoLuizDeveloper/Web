using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Web.Models;

namespace Web.Mappings
{
    public class ProdutoMap : ClassMapping<Produtos>
    {
        public ProdutoMap() 
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Increment);
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
            });
            
            Property(x => x.NomeProduto, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
                x.Column("NomeProduto");
            });
            
            Property(x => x.PrecoCusto, x =>
            {
                x.Type(NHibernateUtil.Double);
                x.Scale(2);
                //x.Precision(2);
                x.NotNullable(true);
                x.Column("PrecoCusto");
            });
            
            Property(x => x.PrecoVenda, x =>
            {
                x.Type(NHibernateUtil.Double);
                x.Scale(2);
                //x.Precision(2);
                x.NotNullable(true);
                x.Column("PrecoVenda");
            });
            
            Property(x => x.ProdutoTipo, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
                x.Column("ProdutoTipo");
            });
            
            Property(x => x.Qtdproduto, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
                x.Column("Qtdproduto");
            });
            
            Property(x => x.Created, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(true);
                x.Column("Created");
            });
            
            Property(x => x.Updated, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.Column("Updated");
            });

            Table("Produtos");
        }
    }
}
