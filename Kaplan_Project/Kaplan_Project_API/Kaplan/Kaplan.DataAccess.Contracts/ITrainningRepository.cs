using Kaplan.Infrastructure;
using System.Collections.Generic;

namespace Kaplan.DataAccess.Contracts
{
    public interface ITrainningRepository
    {
        List<TrainngDetails> TrainningDetails();
    }
}
