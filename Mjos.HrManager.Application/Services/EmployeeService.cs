using Mjos.HrManager.Application.Models.InputModels;
using Mjos.HrManager.Application.Models.ViewModels;
using Mjos.HrManager.Core.Repositories;

namespace Mjos.HrManager.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public AddEmployeeViewModel Add(AddEmployeeInputModel model)
        {
            var employee = model.ToEntity();

            _repository.Add(employee);

            return AddEmployeeViewModel.FromEntity(employee);
        }
    }
}
