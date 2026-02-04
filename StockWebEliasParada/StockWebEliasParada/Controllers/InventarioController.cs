using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockWebEliasParada.Repositories;
using StockWebEliasParada.ViewModels;

[Authorize]
public class InventarioController : Controller
{
    private readonly ElectrodomesticoRepository _repo;

    public InventarioController(ElectrodomesticoRepository repo)
    {
        _repo = repo;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _repo.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Agregar([FromBody] InventarioUpdateVM vm)
    {
        if (!ModelState.IsValid)
            return BadRequest("Datos inválidos");

        var entity = await _repo.GetByIdAsync(vm.ElectrodomesticoId);
        if (entity == null) return NotFound();

        entity.CantidadInventario += vm.Cantidad;

        _repo.Update(entity);
        await _repo.SaveChangesAsync();

        return Json(new { ok = true, cantidad = entity.CantidadInventario });
    }

    [HttpPost]
    public async Task<IActionResult> Vender([FromBody] InventarioUpdateVM vm)
    {
        if (!ModelState.IsValid)
            return BadRequest("Datos inválidos");

        var entity = await _repo.GetByIdAsync(vm.ElectrodomesticoId);
        if (entity == null) return NotFound();

        if (entity.CantidadInventario < vm.Cantidad)
            return BadRequest("Stock insuficiente");

        entity.CantidadInventario -= vm.Cantidad;

        _repo.Update(entity);
        await _repo.SaveChangesAsync();

        return Json(new { ok = true, cantidad = entity.CantidadInventario });
    }
}
