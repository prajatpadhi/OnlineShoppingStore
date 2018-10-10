using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MagicEightBallClassLibrary
{
    [ServiceContract]
    interface IEightBall
    {
        [OperationContract]
        string ObtainAnswerToQuestion(string question);
    }
}
