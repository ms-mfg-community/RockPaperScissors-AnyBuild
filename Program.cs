using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            bool playAgain;
            do
            {
                game.PlayGame();
                playAgain = game.GetPlayAgainChoice();
            } while (playAgain);
        }
    }
}
