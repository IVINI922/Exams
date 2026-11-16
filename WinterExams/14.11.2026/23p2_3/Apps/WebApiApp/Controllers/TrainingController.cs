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
    public class TraininigController : ControllerBase
    {
        [HttpGet("GetAllTrainings")]
        public IActionResult GetAllTrainings()
        {
            List<Training> response = TrainingService.GetAllTrainings();
            return Ok(response);
        }

        [HttpPost("PostNewTraining")]
        public IActionResult PostNewTraining(TrainingDTO trainingDTO)
        {
            TrainingService.PostNewTraining(trainingDTO);
            return Ok();
        }

        [HttpPut("EditTraining")]
        public IActionResult EditTraining(TrainingDTO trainingDTO)
        {
            TrainingService.EditTraining(trainingDTO);
            return Ok();
        }

        [HttpDelete("DeleteTraining")]
        public IActionResult DeleteTraining(int trainingId)
        {
            TrainingService.DeleteTraining(trainingId);
            return Ok();
        }

        [HttpGet("trainingsForTrainer")]
        public IActionResult GetTrainingsForTrainer(int trainerId)
        {
            List<Training> response = TrainingService.GetTrainingsForTrainer(trainerId);
            return Ok(response);
        }

        [HttpPost("ChangeVisitStatus")]
        public IActionResult ChangeVisitStatus(int trainingId)
        {
            TrainingService.ChangeVisitStatus(trainingId);
            return Ok();
        }

        [HttpGet("trainingsForClient")]
        public IActionResult GetTrainingsForClient(int userId)
        {
            List<TrainingDTO> response = TrainingService.GetTrainingsForClient(userId);
            return Ok(response);
        }
    }
}