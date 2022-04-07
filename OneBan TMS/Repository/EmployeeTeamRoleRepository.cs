using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OneBan_TMS.Interfaces;
using OneBan_TMS.Models;
using OneBan_TMS.Models.DTOs;

namespace OneBan_TMS.Repository
{
    public class EmployeeTeamRoleRepository : IEmployeeTeamRoleRepository
    {
        private readonly OneManDbContext _context;
        public EmployeeTeamRoleRepository(OneManDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EmployeeTeamRole>> GetEmployeeTeamRoles()
        {
            return await _context
                .EmployeeTeamRoles
                .ToListAsync();
        }

        public async Task<EmployeeTeamRole> GetEmployeeTeamRoleById(int employeeTeamRoleDto)
        {
            return await _context
                .EmployeeTeamRoles
                .Where(x => x.EtrId == employeeTeamRoleDto)
                .SingleOrDefaultAsync();
        }

        public async Task AddNewEmployeeTeamRole(EmployeeTeamRoleDto employeeTeamRoleDto)
        {
            EmployeeTeamRole newEmployeeTeamRole = new EmployeeTeamRole()
            {
                EtrName = employeeTeamRoleDto.Name,
                EtrDescription = employeeTeamRoleDto.Description
            };
            _context.EmployeeTeamRoles.Add(newEmployeeTeamRole);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeTeamRole(EmployeeTeamRoleDto employeeTeamRoleDto, int employeeTeanRoleId)
        {
            EmployeeTeamRole employeeTeamRoleToUpdate = await _context
                .EmployeeTeamRoles
                .Where(x => x.EtrId == employeeTeanRoleId)
                .SingleOrDefaultAsync();
            if (!(employeeTeamRoleDto is null))
            {
                employeeTeamRoleToUpdate.EtrName = employeeTeamRoleDto.Name;
                employeeTeamRoleToUpdate.EtrDescription = employeeTeamRoleToUpdate.EtrDescription;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEmployeeTeamRole(int employeeTeamRoleId)
        {
            EmployeeTeamRole employeeTeamRoleToDelete = await _context
                .EmployeeTeamRoles
                .Where(x => x.EtrId == employeeTeamRoleId)
                .SingleOrDefaultAsync();
            _context.EmployeeTeamRoles.Remove(employeeTeamRoleToDelete);
            await _context.SaveChangesAsync();
        }
    }
}