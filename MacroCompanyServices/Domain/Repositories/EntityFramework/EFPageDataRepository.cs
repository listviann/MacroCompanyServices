using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace MacroCompanyServices.Domain.Repositories.EntityFramework
{
    public class EFPageDataRepository : IPageDataRepository
    {
        private readonly ApplicationContext _db;

        public EFPageDataRepository(ApplicationContext db)
        {
            _db = db;
        }

        public IQueryable<PageData> GetPagesData() => _db.PagesData;

        public PageData GetPageDataById(Guid id) => _db.PagesData.FirstOrDefault(p => p.Id == id);

        public PageData GetPageDataByCodeWord(string codeWord) => _db.PagesData.FirstOrDefault(p => p.CodeWord == codeWord);

        public void SavePageData(PageData entity)
        {
            if (entity.Id == default)
            {
                _db.Entry(entity).State = EntityState.Added;
            }
            else
            {
                _db.Entry(entity).State = EntityState.Modified;
            }

            _db.SaveChanges();
        }

        public void DeletePageData(Guid id)
        {
            _db.PagesData.Remove(new PageData { Id = id });
            _db.SaveChanges();
        }
    }
}
