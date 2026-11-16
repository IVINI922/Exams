using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Models;
using WebApiApp.Models.DTOModels;

namespace WebApiApp.Services
{
    public class TrainingService
    {
        public static List<Training> GetAllTrainings()
        {
            List<Training> trainings = new();
            using(Winter14112026Context context = new())
            {
                trainings = context.Trainings.ToList();
            }
            return trainings;
        }

        public static void PostNewTraining(TrainingDTO trainingDTO)
        {
            using(Winter14112026Context context = new())
            {
                context.Trainings.Add(new Training{ Date = trainingDTO.Date, Time = trainingDTO.Time, Trainer = trainingDTO.TrainerId, IsVisited = false, Hall = trainingDTO.Hall});
                context.SaveChanges();
            }
        }

        public static void EditTraining(TrainingDTO trainingDTO)
        {
            using(Winter14112026Context context = new())
            {
                Training training = new();
                training = context.Trainings.First(t => t.Id == trainingDTO.Id);
                training.Date = trainingDTO.Date;
                training.Time = trainingDTO.Time;
                training.Trainer = trainingDTO.TrainerId;
                training.IsVisited = trainingDTO.IsVisited;
                training.Hall = trainingDTO.Hall;
                context.SaveChanges();
            }
        }

        public static void DeleteTraining(int trainingId)
        {
            using(Winter14112026Context context = new())
            {
                context.Trainings.Remove(context.Trainings.First(t => t.Id == trainingId));
                context.SaveChanges();
            }
        }

        public static List<Training> GetTrainingsForTrainer(int trainerId)
        {
            List<Training> trainings = new();
            using(Winter14112026Context context = new())
            {
                trainings = context.Trainings.ToList();
            }
            return trainings.FindAll(t => t.Trainer == trainerId);
        }

        public static void ChangeVisitStatus(int trainingId)
        {
            using(Winter14112026Context context = new())
            {
                context.Trainings.ToList().First(t => t.Id == trainingId).IsVisited = !context.Trainings.ToList().First(t => t.Id == trainingId).IsVisited;
                context.SaveChanges();
            }
        }

        public static List<TrainingDTO> GetTrainingsForClient(int userId)
        {
            List<Training> trainings = new();
            List<TrainingList> trainingLists = new();
            List<Client> clients = new();
            using(Winter14112026Context context = new())
            {
                trainings = context.Trainings.ToList();
                trainingLists = context.TrainingLists.ToList();
                clients = context.Clients.ToList();
            }
            Client client = clients.First(c => c.UserId == userId);
            List<TrainingList> clientsTrainingLists = trainingLists.FindAll(tl => tl.Client == client.Id);
            List<TrainingDTO> clientsTraidings = new();
            foreach (TrainingList trainingList in clientsTrainingLists)
            {
                Training currentTraiding = trainings.First(t => t.Id == trainingList.Training);
                clientsTraidings.Add(new TrainingDTO{Id = currentTraiding.Id, Date = currentTraiding.Date, Time = currentTraiding.Time, TrainerId = currentTraiding.Trainer, IsVisited = currentTraiding.IsVisited, Hall = currentTraiding.Hall});
            }
            return clientsTraidings;
        }
    }
}