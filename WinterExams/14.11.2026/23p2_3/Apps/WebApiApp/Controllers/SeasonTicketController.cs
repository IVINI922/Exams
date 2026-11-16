using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Models;
using WebApiApp.Models.DTOModels;
using WebApiApp.Services;

namespace WebApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeasonTicketController : ControllerBase
    {
        [HttpGet("GetAllSeasonTickets")]
        public IActionResult GetAllSeasonTickets()
        {
            List<SeasonTicket> response = SeasonTicketService.GetAllSeasonTickets();
            return Ok(response);
        }

        [HttpPost("PostNewSeasonTicket")]
        public IActionResult PostNewSeasonTicket(SeasonTicketDTO seasonTicketDTO)
        {
            SeasonTicketService.PostNewSeasonTicket(seasonTicketDTO);
            return Ok();
        }

        [HttpPut("EditSeasonTicket")]
        public IActionResult EditSeasonTicket(SeasonTicketDTO seasonTicketDTO)
        {
            SeasonTicketService.EditSeasonTicket(seasonTicketDTO);
            return Ok();
        }

        [HttpDelete("DeleteSeasonTicket")]
        public IActionResult DeleteSeasonTicket(int seasonTicketId)
        {
            SeasonTicketService.DeleteSeasonTicket(seasonTicketId);
            return Ok();
        }
    }
}