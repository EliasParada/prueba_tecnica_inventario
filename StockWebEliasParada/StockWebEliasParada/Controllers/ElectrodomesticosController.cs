using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockWebEliasParada.Models.Entities;
using StockWebEliasParada.Repositories;

[Authorize]
public class ElectrodomesticosController : Controller
{
    private readonly ElectrodomesticoRepository _repo;
    private readonly TipoCategoriaRepository _catRepo;
    private readonly SucursalRepository _sucRepo;

    public ElectrodomesticosController(
        ElectrodomesticoRepository repo,
        TipoCategoriaRepository catRepo,
        SucursalRepository sucRepo)
    {
        _repo = repo;
        _catRepo = catRepo;
        _sucRepo = sucRepo;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Categorias = new SelectList(await _catRepo.GetAllAsync(), "Id", "Nombre");
        ViewBag.Sucursales = new SelectList(await _sucRepo.GetAllAsync(), "Id", "NombreSucursal");
        return View(await _repo.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ElectrodomesticoVM vm)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var entity = new Electrodomestico
        {
            NombreElectrodomestico = vm.NombreElectrodomestico,
            TipoCategoriaId = vm.TipoCategoriaId,
            SucursalId = vm.SucursalId,
            CantidadInventario = vm.CantidadInventario,
            HabilitarProducto = vm.HabilitarProducto
        };

        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();

        return Json(new { ok = true });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [FromBody] ElectrodomesticoVM vm)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity == null) return NotFound();

        entity.NombreElectrodomestico = vm.NombreElectrodomestico;
        entity.TipoCategoriaId = vm.TipoCategoriaId;
        entity.SucursalId = vm.SucursalId;
        entity.CantidadInventario = vm.CantidadInventario;
        entity.HabilitarProducto = vm.HabilitarProducto;

        _repo.Update(entity);
        await _repo.SaveChangesAsync();

        return Json(new { ok = true });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity == null) return NotFound();

        _repo.Delete(entity);
        await _repo.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
