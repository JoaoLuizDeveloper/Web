using Web.Models;
using NHibernate;

namespace Web.Repositories
{
    public class ProdutoRepository : IRepository<Produtos>
    {
        private NHibernate.ISession _session;

        public ProdutoRepository(NHibernate.ISession session) => _session = session;
        
        public async Task Add(Produtos obj)
        {
            ITransaction transaction = _session.BeginTransaction();
            try
            {
                await _session.SaveAsync(obj);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await transaction.RollbackAsync();
            }
            finally 
            { 
                transaction?.Dispose(); 
            }
        }
        
        public IEnumerable<Produtos> GetAll() => _session.Query<Produtos>().ToList();

        public async Task<Produtos> GetOne(int id) => await _session.GetAsync<Produtos>(id);

        public async Task Remove(int id)
        {
            ITransaction transaction = _session.BeginTransaction();
            try
            {
                transaction = _session.BeginTransaction();
                var obj = await _session.GetAsync<Produtos>(id);
                await _session.DeleteAsync(obj);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await transaction.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }
        } 
        
        public async Task Update(Produtos obj)
        {
            ITransaction transaction = _session.BeginTransaction();
            try
            {
                transaction = _session.BeginTransaction();
                await _session.UpdateAsync(obj);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await transaction.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }
        }        
    }
}
