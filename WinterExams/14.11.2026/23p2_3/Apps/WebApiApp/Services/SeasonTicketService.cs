using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Models;
using WebApiApp.Models.DTOModels;

namespace WebApiApp.Services
{
    public class SeasonTicketService
    {
        public static List<SeasonTicket> GetAllSeasonTickets()
        {
            List<SeasonTicket> seasonTickets = new();
            using(Winter14112026Context context = new())
            {
                seasonTickets = context.SeasonTickets.ToList();
            }
            return seasonTickets;
        }

        public static void PostNewSeasonTicket(SeasonTicketDTO seasonTicketDTO)
        {
            using(Winter14112026Context context = new())
            {
                context.SeasonTickets.Add(new SeasonTicket{ Type = seasonTicketDTO.Type, StartDate = seasonTicketDTO.StartDate, EndDate = seasonTicketDTO.EndDate});
                context.SaveChanges();
            }
        }

        public static void EditSeasonTicket(SeasonTicketDTO seasonTicketDTO)
        {
            using(Winter14112026Context context = new())
            {
                SeasonTicket seasonTicket = new();
                seasonTicket = context.SeasonTickets.First(t => t.Id == seasonTicketDTO.Id);
                seasonTicket.Type = seasonTicketDTO.Type;
                seasonTicket.StartDate = seasonTicketDTO.StartDate;
                seasonTicket.EndDate = seasonTicketDTO.EndDate;
                context.SaveChanges();
            }
        }

        public static void DeleteSeasonTicket(int seasonTicketId)
        {
            using(Winter14112026Context context = new())
            {
                context.SeasonTickets.Remove(context.SeasonTickets.First(t => t.Id == seasonTicketId));
                context.SaveChanges();
            }
        }
    }
}