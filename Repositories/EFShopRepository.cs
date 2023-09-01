using midterm_project.Migrations;
using midterm_project.Models;

namespace midterm_project.Repositories;

public class EFShopRepository : IShopRepository
{
    private readonly ShopDbContext _context;

    public EFShopRepository(ShopDbContext context)
    {
        _context = context;
    }

    Shop IShopRepository.CreateShop(Shop newShop)
    {
        _context.Shop.Add(newShop);
        _context.SaveChanges();
        return newShop;
    }

    void IShopRepository.DeleteShopById(int shopId)
    {
        var shop = _context.Shop.Find(shopId);
        if (shop != null)
        {
            _context.Shop.Remove(shop);
            _context.SaveChanges();
        }
    }

    IEnumerable<Shop> IShopRepository.GetAllShop()
    {
        return _context.Shop.ToList();
    }

    Shop? IShopRepository.GetShopById(int shopId)
    {
        return _context.Shop.SingleOrDefault(c => c.ShopId == shopId);
    }

    Shop? IShopRepository.UpdateShop(Shop newShop)
    {
        var originalShop = _context.Shop.Find(newShop.ShopId);
        if (originalShop != null)
        {
            originalShop.Name = newShop.Name;
            originalShop.ImgUrl = newShop.ImgUrl;
            originalShop.Description = newShop.Description;
            originalShop.TypeOfDino = newShop.TypeOfDino;
            originalShop.Price = newShop.Price;
            _context.SaveChanges();
        }
        return originalShop;
    }
}