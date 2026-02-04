using Microsoft.EntityFrameworkCore;
using StockWebEliasParada.Data;
using StockWebEliasParada.Models.Entities;

namespace StockWebEliasParada.Repositories
{
    public class ElectrodomesticoRepository : Repository<Electrodomestico>
    {
        public ElectrodomesticoRepository(AppDbContext db) : base(db)
        {
        }

        public override async Task<IEnumerable<Electrodomestico>> GetAllAsync()
        {
            return await _db.Electrodomesticos
                .Include(e => e.TipoCategoria)
                .Include(e => e.Sucursal)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
