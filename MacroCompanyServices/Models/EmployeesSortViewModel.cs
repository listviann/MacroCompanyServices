namespace MacroCompanyServices.Models
{
    public enum EmployeesSortState
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
        DateAddedAsc,
        DateAddedDesc
    }

    public class EmployeesSortViewModel
    {
        public EmployeesSortState EmployeeNameSort { get; }
        public EmployeesSortState EmployeeEmailSort { get; }
        public EmployeesSortState EmployeePhoneNumberSort { get; }
        public EmployeesSortState EmployeeSalarySort { get; }
        public EmployeesSortState EmployeeBirthDateSort { get; }
        public EmployeesSortState EmployeePositionSort { get; }
        public EmployeesSortState EmployeeDateAddedSort { get; }
        public EmployeesSortState Current { get; }

        public EmployeesSortViewModel(EmployeesSortState sortOrder)
        {
            EmployeeNameSort = sortOrder == EmployeesSortState.EmployeeNameAsc ? EmployeesSortState.EmployeeNameDesc : EmployeesSortState.EmployeeNameAsc;
            EmployeeEmailSort = sortOrder == EmployeesSortState.EmployeeEmailAsc ? EmployeesSortState.EmployeeEmailDesc : EmployeesSortState.EmployeeEmailAsc;
            EmployeePhoneNumberSort = sortOrder == EmployeesSortState.EmployeePhoneNumberAsc ? EmployeesSortState.EmployeePhoneNumberDesc : EmployeesSortState.EmployeePhoneNumberAsc;
            EmployeeSalarySort = sortOrder == EmployeesSortState.EmployeeSalaryAsc ? EmployeesSortState.EmployeeSalaryDesc : EmployeesSortState.EmployeeSalaryAsc;
            EmployeeBirthDateSort = sortOrder == EmployeesSortState.EmployeeBirthDateAsc ? EmployeesSortState.EmployeeBirthDateDesc : EmployeesSortState.EmployeeBirthDateAsc;
            EmployeePositionSort = sortOrder == EmployeesSortState.EmployeePositionAsc ? EmployeesSortState.EmployeePositionDesc : EmployeesSortState.EmployeePositionAsc;
            EmployeeDateAddedSort = sortOrder == EmployeesSortState.DateAddedAsc ? EmployeesSortState.DateAddedDesc : EmployeesSortState.DateAddedAsc;
            Current = sortOrder;
        }
    }
}
