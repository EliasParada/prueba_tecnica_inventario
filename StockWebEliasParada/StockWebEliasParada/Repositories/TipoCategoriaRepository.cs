using StockWebEliasParada.Data;
using StockWebEliasParada.Models.Entities;

namespace StockWebEliasParada.Repositories
{
    public class TipoCategoriaRepository : Repository<TipoCategoria>
    {
        public TipoCategoriaRepository(AppDbContext db) : base(db)
        {
        }
    }
}
