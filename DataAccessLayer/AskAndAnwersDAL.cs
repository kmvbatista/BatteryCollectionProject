using System.Collections.Generic;
using System.Linq;
using DataTypeObject;

namespace DataAccessLayer
{
    public class AskAndAnswersDAL : IAsksAndAnswersDAL
    {
        private readonly BatteryCollectorDbContext discardsDbContext;

        public AskAndAnswersDAL(BatteryCollectorDbContext _discardsDbContext)
        {
            discardsDbContext = _discardsDbContext;
        }
        public List<AskAndAnswers> GetAll()
        {
            return discardsDbContext.AskAndAnswers.ToList();
        }
    }
}
