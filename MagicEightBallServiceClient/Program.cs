using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicEightBallServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******** Ask the Magic 8 ball *****\n");
            using (EightBallClient ball = new EightBallClient())
            {
                Console.WriteLine("Your question:");
                string q = Console.ReadLine();
                string answer = ball.ObtainAnswerToQuestion(q);
                Console.WriteLine($"Eight ball says: {answer}");
                Console.ReadLine();
            }
        }
    }
}
