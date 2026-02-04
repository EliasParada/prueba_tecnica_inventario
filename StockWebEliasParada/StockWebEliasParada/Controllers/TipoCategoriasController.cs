using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockWebEliasParada.Models.Entities;
using StockWebEliasParada.Repositories;

[Authorize]
public class TipoCategoriasController : Controller
{
    private readonly TipoCategoriaRepository _repo;

    public TipoCategoriasController(TipoCategoriaRepository repo)
    {
        _repo = repo;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _repo.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(TipoCategoria model)
    {
        if (!ModelState.IsValid)
            return RedirectToAction(nameof(Index));

        await _repo.AddAsync(model);
        await _repo.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TipoCategoria model)
    {
        _repo.Update(model);
        await _repo.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
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
