using System.Collections.Generic;

namespace DataTypeObject
{
    public interface IAsksAndAnswersDAL
    {
        List<AskAndAnswers> GetAll();
    }
}
