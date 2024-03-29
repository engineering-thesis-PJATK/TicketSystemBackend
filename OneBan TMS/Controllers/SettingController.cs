using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneBan_TMS.Interfaces.Repositories;
using OneBan_TMS.Models;
using OneBan_TMS.Models.DTOs.Messages;
using OneBan_TMS.Models.DTOs.Setting;
using OneBan_TMS.Providers;

namespace OneBan_TMS.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class SettingController : Controller
    {
        private readonly ISettingRepository _settingRepository;
        public SettingController(OneManDbContext context, ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        [HttpGet("/Users/Roles")]
        public async Task<ActionResult<List<UserPrivileges>>> GetUsersWithRoles()
        {
            var usersWithRoles = await _settingRepository.GetUserWithPrivileges();
            return Ok(usersWithRoles);
        }
        [HttpPost("/TicketPriority")]
        public async Task<IActionResult> AddTicketPriority(NewTicketPriorityDto newTicketPriorityDto)
        {
            await _settingRepository.AddTicketPriority(newTicketPriorityDto);
            return Ok(MessageProvider.GetSuccessfulMessage("Added successfully ticket priority"));
        }
        [HttpPost("/TicketType")]
        public async Task<IActionResult> AddTicketType(NewTicketTypeDto newTicketTypeDto)
        {
            await _settingRepository.AddTicketType(newTicketTypeDto);
            return Ok(MessageProvider.GetSuccessfulMessage("Added successfully ticket type"));
        }
        [HttpPost("/TicketStatus")]
        public async Task<IActionResult> AddTicketStatus(NewTicketStatusDto newTicketStatusDto)
        {
            await _settingRepository.AddTicketStatus(newTicketStatusDto);
            return Ok(MessageProvider.GetSuccessfulMessage("Added successfully ticket status"));
        }
    }
}