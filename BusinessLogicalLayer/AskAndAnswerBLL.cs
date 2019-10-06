using DataTypeObject;
using System.Collections.Generic;

namespace BusinessLogicalLayer
{
    public class AskAndAnswerBLL : IAsksAndAnswersCrud
    {
        private readonly IAsksAndAnswersDAL asksAndAnswersDAL;
        public AskAndAnswerBLL(IAsksAndAnswersDAL _asksAndAnswersDAL)
        {
            this.asksAndAnswersDAL = _asksAndAnswersDAL;
        }

        public List<AskAndAnswers> GetAll()
        {
            return asksAndAnswersDAL.GetAll();
        }
    }
}
