using Kaplan.Business.Contracts;
using Kaplan.DataAccess.Contracts;
using Kaplan.Infrastructure;
using System.Collections.Generic;

namespace Kaplan.Business.Service
{
    public class TrainningService : ITrainningService
    {
        private readonly ITrainningRepository _trainningRepository;
        
        public TrainningService(ITrainningRepository TrainningRepository)
        {

            _trainningRepository = TrainningRepository;            
        }

        public List<TrainngDetails> TrainningDetails()
        {
            return _trainningRepository.TrainningDetails();
        }
    }
}
