using System.Collections.Generic;
using System.Threading.Tasks;
using OneBan_TMS.Models;
using OneBan_TMS.Models.DTOs.Kanban;
using OneBan_TMS.Models.DTOs.OrganizationalTask;

namespace OneBan_TMS.Interfaces.Repositories
{
    public interface IOrganizationalTaskRepository
    {
        Task<List<KanbanElement>> GetTaskForEmployee(int statusId, int employeeId);
        Task UpdateTaskStatus(int taskId, int statusId);
        Task<OrganizationalTask> AddNewOrganizationalTask(NewOrganizationalTask newOrganizationalTask);
    
    }
}