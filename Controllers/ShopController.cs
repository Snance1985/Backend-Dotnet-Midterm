using Microsoft.AspNetCore.Mvc;
using midterm_project.Repositories;
using midterm_project.Models;

namespace midterm_project.Controllers;

public class ShopController : Controller
{
    private readonly ILogger<ShopController> _logger;
    private readonly IShopRepository _shopRepository;

    public ShopController(ILogger<ShopController> logger, IShopRepository repository)
    {
        _logger = logger;
        _shopRepository = repository;
    }

    public IActionResult Index()
    {
        // return View(_shopRepository.GetAllShop());
        return RedirectToAction ("List");
    }

        public IActionResult List()
    {
        return View(_shopRepository.GetAllShop());
    }

    [HttpGet]
    public IActionResult Detail(int id)
    {
        var shop = _shopRepository.GetShopById(id);

        if (shop == null)
        {
            return RedirectToAction("List");
        }

        return View(shop);
    }




    [HttpGet]
    public IActionResult Edit(int id)
    {
        var shop = _shopRepository.GetShopById(id);

        if (shop == null)
        {
            return RedirectToAction("List");
        }

        return View(shop);
    }

    [HttpPost]
    public IActionResult Edit(Shop shop)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _shopRepository.UpdateShop(shop);

        return RedirectToAction("Detail", new { id = shop.ShopId });
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Shop shop)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _shopRepository.CreateShop(shop);

        return RedirectToAction("Detail", new { id = shop.ShopId });

    }

    public IActionResult Delete(int id)
    {
        _shopRepository.DeleteShopById(id);

        return RedirectToAction("List");
    }

}