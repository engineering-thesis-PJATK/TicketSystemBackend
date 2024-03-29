using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneBan_TMS.Models;
using OneBan_TMS.Models.DTOs;

namespace OneBan_TMS.Controllers
{
    [Route("api/[controller]")]
    [Authorize] 
    [ApiController]
    public class HomeController : ControllerBase
    {
        private OneManDbContext _dbContext;

        public HomeController(OneManDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}