using Mjos.HrManager.Core.Entities;
using Mjos.HrManager.Core.Enums;

namespace Mjos.HrManager.Application.Models.InputModels
{
    public class AddEmployeeInputModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public int RoleLevel { get; set; }
        public string Role { get; set; } = string.Empty;

        public Employee ToEntity()
            => new(FullName, Document, BirthDate, (RoleLevel)RoleLevel, Role);
    }
}
