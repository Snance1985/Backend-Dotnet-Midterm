using midterm_project.Models;

namespace midterm_project.Repositories;

public interface IShopRepository
{
    IEnumerable<Shop> GetAllShop();
    Shop? GetShopById(int shopId);
    Shop CreateShop(Shop shop);
    Shop? UpdateShop(Shop shop);
    void DeleteShopById(int shopId);
}
