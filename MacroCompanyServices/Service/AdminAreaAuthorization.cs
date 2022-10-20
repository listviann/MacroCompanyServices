using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace MacroCompanyServices.Service
{
    // Convention: only user who is authorized as admin has an access to admin panel
    public class AdminAreaAuthorization : IControllerModelConvention
    {
        private readonly string _area;
        private readonly string _policy;

        public AdminAreaAuthorization(string area, string policy)
        {
            _area = area;
            _policy = policy;
        }

        // Check attributes of the controller
        public void Apply(ControllerModel controller)
        {
            if (controller.Attributes.Any(a => 
                a is AreaAttribute 
                && (a as AreaAttribute).RouteValue.Equals(_area, StringComparison.OrdinalIgnoreCase)) 
                || controller.RouteValues.Any(r => 
                r.Key.Equals("area", StringComparison.OrdinalIgnoreCase) 
                && r.Value.Equals(_area, StringComparison.OrdinalIgnoreCase)))
            {
                controller.Filters.Add(new AuthorizeFilter(_policy));
            }
        }
    }
}
