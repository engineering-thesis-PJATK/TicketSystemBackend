using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneBan_TMS.Models;
using OneBan_TMS.Models.DTOs;
using OneBan_TMS.Models.DTOs.Ticket;

namespace OneBan_TMS.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        Task<TicketDto> GetTicketById(int ticketId);
        Task<List<TicketDto>> GetTickets();
        Task<List<TicketTypeDto>> GetTicketTypes();
        Task<TicketTypeDto> GetTicketTypeById(int ticketTypeId);
        Task<List<TicketPriorityDto>> GetTicketPriorities();
        Task<TicketPriorityDto> GetTicketPriorityById(int ticketPriorityId);
        Task<TicketDto> UpdateTicket(int ticketId, TicketUpdateDto ticketUpdate);
        Task<TicketDto> UpdateTicketStatusId(int ticketId, int ticketStatusId);
        Task<List<TicketStatusDto>> GetTicketStatuses();
        Task<TicketStatusDto> GetTicketStatusById(int ticketStatusId);
        Task DeleteTicketById(int ticketId);
    }
}