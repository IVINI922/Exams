using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Models.DTOModels
{
    public class SeasonTicketDTO
    {
        public int Id {get; set;}
        public int Type {get; set;}
        public DateOnly StartDate {get; set;}
        public DateOnly EndDate {get; set;}
    }
}