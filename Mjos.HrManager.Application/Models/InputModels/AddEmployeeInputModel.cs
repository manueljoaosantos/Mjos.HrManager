using Mjos.HrManager.Core.Entities;
using Mjos.HrManager.Core.Enums;

namespace Mjos.HrManager.Application.Models.InputModels
{
    public class AddEmployeeInputModel
    {
        public string FullName { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public int RoleLevel { get; set; }
        public string Role { get; set; }

        public Employee ToEntity()
            => new(FullName, Document, BirthDate, (RoleLevel)RoleLevel, Role);
    }
}
