using MacroCompanyServices.Domain.Entities;

namespace MacroCompanyServices.Domain.Repositories.Abstract
{
    public interface IPageDataRepository
    {
        IQueryable<PageData> GetPagesData();
        PageData GetPageDataById(Guid id);
        PageData GetPageDataByCodeWord(string codeWord);
        void SavePageData(PageData entity);
        void DeletePageData(Guid id);
    }
}
