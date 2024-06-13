using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors_1
{
    internal class Game
    {
        private int userScore = 0;
        private int computerScore = 0;

        private string DetermineWinner(string userChoice, string computerChoice)
        {
            if (userChoice == computerChoice)
            {
                return "It's a tie!";
            }
            else
            {
                if (userChoice == "rock" && computerChoice == "scissors" ||
                    userChoice == "paper" && computerChoice == "rock" ||
                    userChoice == "scissors" && computerChoice == "paper")
                {
                    userScore++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "You win!";
                }
                else
                {
                    computerScore++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    return "You lose!";
                }
            }
        }

        // create a rock paper scissors game
        // 1. ask user to input rock paper or scissors
        // 2. have the computer select a random choice
        // 3. compare the two choices and send out the results
        // 4. ask the user if they want to play again

        public void PlayGame()
        {
            Console.WriteLine("Welcome to Rock Paper Scissors!");
            string userChoice = GetUserChoice();

            if (userChoice == string.Empty)
            {
                Console.WriteLine("Invalid choice, please enter rock, paper, or scissors.");
                // continue if user choice is empty
                return;
            }
            DisplayChoice(userChoice);

            string computerChoice = GetComputerChoice();

            Console.WriteLine($"The computer chose {computerChoice}");
            DisplayChoice(computerChoice);

            string result = DetermineWinner(userChoice, computerChoice);
            Console.WriteLine(result);
            Console.ResetColor();

            DisplayScore();        
            // No need to call PlayGame() again here, we'll handle replaying in the Main() method
        }

        public bool GetPlayAgainChoice()
        {
            Console.WriteLine("Do you want to play again? yes or no");
            string input = Console.ReadLine().ToLower();

            return input.StartsWith("y");
        }

        private string GetUserChoice()
        {
            string input = string.Empty;
            do
            {
                Console.WriteLine("Please enter your choice: rock, paper, or scissors");
                input = Console.ReadLine().ToLower();

                if (input == "r" || input == "rock")
                {
                    return "rock";
                }
                else if (input == "p" || input == "paper")
                {
                    return "paper";
                }
                else if (input == "s" || input == "scissors")
                {
                    return "scissors";
                }
                else
                {
                    Console.WriteLine("Invalid choice, please enter rock, paper, or scissors.");
                }
            } while (true);
        }

        private string GetComputerChoice()
        {
            Random random = new Random();
            int choice = random.Next(1, 4);
            switch (choice)
            {
                case 1:
                    return "rock";
                case 2:
                    return "paper";
                case 3:
                    return "scissors";
                default:
                    return "rock";
            }
        }
        private void DisplayScore()
        {
            Console.WriteLine($"Score: You - {userScore} | Computer - {computerScore}");
        }
        private void DisplayChoice(string choice)
        {
            switch (choice)
            {
                case "rock":
                    Console.WriteLine(@"
            _______
        ---'   ____)
              (_____)
              (_____)
              (____)
        ---.__(___)
        ");
                    break;
                case "paper":
                    Console.WriteLine(@"
             _______
        ---'    ____)____
                   ______)
                  _______)
                 _______)
        ---.__________)
        ");
                    break;
                case "scissors":
                    Console.WriteLine(@"
            _______
        ---'   ____)____
                  ______)
               __________)
              (____)
        ---.__(___)
        ");
                    break;
            }
        }

        
    }
}
