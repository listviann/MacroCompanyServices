using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Domain.Repositories.Abstract;

namespace MacroCompanyServices.Domain.Repositories.EntityFramework
{
    public class EFCartItemRepository : ICartItemRepository
    {
        private readonly MacroCompanyContext _db;

        public EFCartItemRepository(MacroCompanyContext db)
        {
            _db = db;
        }

        public void Save(Guid prodId, Guid userId)
        {
            CartItem item = new CartItem() { Id = Guid.NewGuid(), ProductId = prodId, UserId = userId };
            _db.CartItems.Add(item);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            CartItem item = new CartItem { Id = id };
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
        }

        public IQueryable<CartItem> GetCartItems()
        {
            return _db.CartItems;
        }

        public CartItem GetCartItemById(Guid id)
        {
            return _db.CartItems.FirstOrDefault(c => c.Id == id);
        }
    }
}
