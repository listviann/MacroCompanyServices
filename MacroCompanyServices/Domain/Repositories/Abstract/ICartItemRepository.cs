using MacroCompanyServices.Domain.Entities;

namespace MacroCompanyServices.Domain.Repositories.Abstract
{
    public interface ICartItemRepository
    {
        IQueryable<CartItem> GetCartItems();
        CartItem GetCartItemById(Guid id);
        void Save(Guid prodId, Guid userId);
        void Delete(Guid id);
    }
}
