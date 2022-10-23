namespace MacroCompanyServices.Areas.Admin.Models
{
    public enum PagesDataSortState
    {
        CodeWordAsc,
        CodeWordDesc,
        TitleAsc,
        TitleDesc,
        TextAsc,
        TextDesc
    }

    public class PagesDataSortViewModel
    {
        public PagesDataSortState CodeWordSort { get; }
        public PagesDataSortState TitleSort { get; }
        public PagesDataSortState TextSort { get; }
        public PagesDataSortState Current { get; }

        public PagesDataSortViewModel(PagesDataSortState sortOrder)
        {
            CodeWordSort = sortOrder == PagesDataSortState.CodeWordAsc ? PagesDataSortState.CodeWordDesc : PagesDataSortState.CodeWordAsc;
            TitleSort = sortOrder == PagesDataSortState.TitleAsc ? PagesDataSortState.TitleDesc : PagesDataSortState.TitleAsc;
            TextSort = sortOrder == PagesDataSortState.TextAsc ? PagesDataSortState.TextDesc : PagesDataSortState.TextAsc;
            Current = sortOrder;
        }
    }
}
