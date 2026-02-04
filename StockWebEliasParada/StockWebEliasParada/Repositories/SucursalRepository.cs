using StockWebEliasParada.Data;
using StockWebEliasParada.Models.Entities;

namespace StockWebEliasParada.Repositories
{
    public class SucursalRepository : Repository<Sucursal>
    {
        public SucursalRepository(AppDbContext db) : base(db)
        {
        }
    }
}
