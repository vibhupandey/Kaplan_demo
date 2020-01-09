using Kaplan.Infrastructure;
using System.Collections.Generic;

namespace Kaplan.Business.Contracts
{
    public interface ITrainningService
    {
        List<TrainngDetails> TrainningDetails();
    }
}
