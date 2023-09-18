using Mjos.HrManager.Application.Models.InputModels;
using Mjos.HrManager.Application.Models.ViewModels;

namespace Mjos.HrManager.Application.Services
{
    public interface IEmployeeService
    {
        AddEmployeeViewModel Add(AddEmployeeInputModel model);
    }
}
