﻿using Mjos.HrManager.Core.Entities;
using Mjos.HrManager.Core.Repositories;

namespace Mjos.HrManager.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HrManagerDbContext _context;

        public EmployeeRepository(HrManagerDbContext context)
        {
            _context = context;
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);

            _context.SaveChanges();
        }
    }
}
