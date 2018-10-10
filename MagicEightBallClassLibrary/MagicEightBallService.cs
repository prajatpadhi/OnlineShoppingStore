using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MagicEightBallClassLibrary
{
    public class MagicEightBallService : IEightBall
    {
        public MagicEightBallService()
        {
            Console.WriteLine("The 8-ball awaits your question");
        }

        public string ObtainAnswerToQuestion(string question)
        {
            string[] answers = { "Future uncertain","Yes","No","Hazy","Ask again later","Definitely"};
            Random r = new Random();
            return answers[r.Next(answers.Length)];
        }
    }
}
