using System;
namespace RockPaperScissorsCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                string[] choices = { "rock", "paper", "scissors" };

                //Random object to let computer choose a random choice
                Random random = new Random();

                // Keeping track of the score with wins, losses, and ties
                int wins = 0, losses = 0, ties = 0;
                int roundsPlayedByUser = 0;
                int totalRounds = 5;        //best of 5 rounds

                //Displaying the welcome message
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("    Created by Toby Crabtree. Follow the instagram @tobycrabtree_\n");
                Console.WriteLine("                  Welcome to Rock, Paper, Scissors!");
                Console.WriteLine($"This game is the best of {totalRounds} rounds. So first to 3 wins, wins the game!");
                Console.WriteLine("  Enter your choice: rock, paper, or scissors. To exit, type 'quit'");
                Console.WriteLine("---------------------------------------------------------------------");

                //Infinite loop to keep the game running until the user types 'quit'
                while (roundsPlayedByUser < totalRounds)
                {
                    Console.WriteLine($"\n                 Round {roundsPlayedByUser + 1} of {totalRounds}");
                    Console.WriteLine("-----------------------------------------------");
                    
                    //Getting the user's choice
                    Console.Write("Your choice (rock, paper, scissors, or quit): ");
                    string userChoice = Console.ReadLine().Trim().ToLower();   //Converting the user's choice to lowercase

                    //Checking if the user's wants to quit
                    if (userChoice.StartsWith("quit"))
                    {
                        Console.WriteLine("\nThe game was ended early");
                        Console.WriteLine("Final Score:");
                        Console.WriteLine($"Wins: {wins}, Losses: {losses}, Ties: {ties}");
                        Console.WriteLine("Thanks for playing!");
                        break;
                    }

                    //check if input is valid
                    if (userChoice != "rock" && userChoice != "paper" && userChoice != "scissors")
                    {
                        Console.WriteLine("Invalid input. Please enter rock, paper, or scissors correctly.");
                        continue;   //Skip the rest of the code and start the loop again
                                    // AKA go back to the beginning of the loop
                    }

                    //convert userchoice to lowercase
                    userChoice = userChoice.ToLower();

                    //computer makes random choice
                    string computerChoice = choices[random.Next(3)];
                    Console.WriteLine("Computer's choice: " + computerChoice);

                    //Determining the winner
                    if (userChoice == computerChoice)
                    {
                        Console.WriteLine("It's a tie on this round!");
                        ties++;
                    }
                    else if (userChoice == "rock" && computerChoice == "scissors" ||
                             userChoice == "paper" && computerChoice == "rock" ||
                             userChoice == "scissors" && computerChoice == "paper")
                    {
                        Console.WriteLine("You win this round!");
                        wins++;
                    }
                    else
                    {
                        Console.WriteLine("You lost this round!");
                        losses++;
                    }
                    
                    //increment the rounds played by user
                    roundsPlayedByUser++;

                    // Check if a player has won 3 rounds (Early Victory Condition)
                    if (wins == 3 || losses == 3)
                    {
                        Console.WriteLine("\nA player has reached 3 wins! Ending the game early.");
                        break;
                    }
                }
                

                //display the results
                //Displaying the results
                Console.WriteLine("\nThe game is over! These are your final results:");
                Console.WriteLine($"    Wins: {wins} | Losses: {losses} | Ties: {ties}");

                if (wins > losses)
                {
                    Console.WriteLine("    Congratulations! You won the game!");
                }
                else if (losses > wins)
                {
                    Console.WriteLine("    You lost the game! Good try though.");
                }
                else
                {
                    Console.WriteLine("    The game ended in a tie!");

                }

                Console.Write("\nDo you want to play again? (yes/no): ");
                string playAgainInput = Console.ReadLine().Trim().ToLower();

                if (playAgainInput != "yes" && playAgainInput != "y")
                {
                    playAgain = false;
                    Console.WriteLine("\nThanks for playing... Goodbye\n");
                }
               
            }
        }
    }
}

