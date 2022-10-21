namespace MacroCompanyServices.Models
{
    public enum SortState
    {
        EmployeeNameAsc,
        EmployeeNameDesc,
        EmployeeEmailAsc,
        EmployeeEmailDesc,
        EmployeePhoneNumberAsc,
        EmployeePhoneNumberDesc,
        EmployeeSalaryAsc,
        EmployeeSalaryDesc,
        EmployeeBirthDateAsc,
        EmployeeBirthDateDesc,
        EmployeePositionAsc,
        EmployeePositionDesc,
        ProductNameAsc,
        ProductNameDesc,
        ProductTypeNameAsc,
        ProductTypeNameDesc,
        DateAddedAsc,
        DateAddedDesc
    }

    public class SortViewModel
    {
        public SortState EmployeeNameSort { get; }
        public SortState EmployeeEmailSort { get; }
        public SortState EmployeePhoneNumberSort { get; }
        public SortState EmployeeSalarySort { get; }
        public SortState EmployeeBirthDateSort { get; }
        public SortState EmployeePositionSort { get; }
        public SortState ProductNameSort { get; }
        public SortState ProductTypeNameSort { get; }
        public SortState DateAddedSort { get; }
        public SortState Current { get; }

        public SortViewModel(SortState sortOrder)
        {
            EmployeeNameSort = sortOrder == SortState.EmployeeNameAsc ? SortState.EmployeeNameDesc : SortState.EmployeeNameAsc;
            EmployeeEmailSort = sortOrder == SortState.EmployeeEmailAsc ? SortState.EmployeeEmailDesc : SortState.EmployeeEmailAsc;
            EmployeePhoneNumberSort = sortOrder == SortState.EmployeePhoneNumberAsc ? SortState.EmployeePhoneNumberDesc : SortState.EmployeePhoneNumberDesc;
            EmployeeSalarySort = sortOrder == SortState.EmployeeSalaryAsc ? SortState.EmployeeSalaryDesc : SortState.EmployeeSalaryAsc;
            EmployeeBirthDateSort = sortOrder == SortState.EmployeeBirthDateAsc ? SortState.EmployeeBirthDateDesc : SortState.EmployeeBirthDateDesc;
            EmployeePositionSort = sortOrder == SortState.EmployeePositionAsc ? SortState.EmployeePositionDesc : SortState.EmployeePositionAsc;
            ProductNameSort = sortOrder == SortState.ProductNameAsc ? SortState.ProductNameDesc : SortState.ProductNameAsc;
            ProductTypeNameSort = sortOrder == SortState.ProductTypeNameAsc ? SortState.ProductTypeNameDesc : SortState.ProductTypeNameAsc;
            DateAddedSort = sortOrder == SortState.DateAddedAsc ? SortState.DateAddedDesc : SortState.DateAddedAsc;
            Current = sortOrder;
        }
    }
}
