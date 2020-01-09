using Kaplan.DataAccess.Contracts;
using Kaplan.Infrastructure;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kaplan.DataAccess.Service
{
    public class TrainningRepostory : ITrainningRepository
    {
        public List<TrainngDetails> TrainningDetails()
        {
            var items = new List<TrainngDetails>(); 
            using (StreamReader r = new StreamReader("../Kaplan.Infrastructure/channel.json"))
            {
                string json = r.ReadToEnd();
                  items = JsonConvert.DeserializeObject<List<TrainngDetails>>(json);
            }
            return items.OrderBy(x => x.Time ).ToList();  
        } 
    }
}
