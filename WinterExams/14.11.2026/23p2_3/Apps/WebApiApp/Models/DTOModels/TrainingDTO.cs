using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Models.DTOModels
{
    public class TrainingDTO
    {
        public int Id {get; set;}
        public DateOnly Date {get; set;}
        public TimeOnly Time {get; set;}
        public int TrainerId {get; set;}
        public bool IsVisited {get; set;}
        public int Hall {get; set;}
    }
}