using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 0;//first number in the range
            int max = 0;//last number in the range
            int userInput = 0;
            Random random = new Random();
            int generatedNumber;
            decimal jackpot = 1000000;
            decimal moneyWon = 0;
            string moneyFormatted;
            bool isRunning = true;
            string answer = " ";//changes the value of bool isRunning depending on the user's input

            while (isRunning)
            {
                Console.WriteLine("Enter the first number in the range: ");
                min = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the last number in the range: ");
                max = int.Parse(Console.ReadLine());
                Console.WriteLine(" ");


                int[] winningNumbers = new int[6];

                for (int i = 0; i < winningNumbers.Length; i++)
                {
                    generatedNumber = random.Next(min, (max + 1)); //+1 ensures that the max number is within the range

                    /*If the random number assigned to generatedNumber is already presented 
                     * in the winningNumbers array, it's going to keep getting a different
                     * random value until it has a unique value
                    */
                    while (winningNumbers.Contains(generatedNumber))
                    {
                        generatedNumber = random.Next(min, (max + 1));
                    }

                    winningNumbers[i] = generatedNumber;//assigns generatedNumber to the array
                    Console.WriteLine("Lucky Number: " + generatedNumber);

                }

                Console.WriteLine(" ");

                int[] pickedNumbers = new int[6];
                Console.WriteLine("Enter your " + pickedNumbers.Length + " lucky numbers");
                Console.WriteLine("(Do not repeat numbers)");
                for (int i = 0; i < pickedNumbers.Length; i++)
                {
                    Console.WriteLine("Number#" + (i + 1) + ":");
                    userInput = int.Parse(Console.ReadLine());

                    //Checks if a number is unique and within the range
                    while ((userInput < min) || (userInput > max) || (pickedNumbers.Contains(userInput)))
                    {
                        Console.WriteLine("All the numbers need to be unique and within the range. Try again.");
                        Console.WriteLine("Number#" + (i + 1) + ":");
                        userInput = int.Parse(Console.ReadLine());
                    }

                    pickedNumbers[i] = userInput;

                }
                Console.WriteLine("");
                
                //test Displays all the picked numbers
                //Console.WriteLine("Your numbers are: ");
                //for (int i = 0; i < pickedNumbers.Length; i++)
                //{
                //    Console.WriteLine(pickedNumbers[i]);
                //}


                //checks for matches between 2 arrays
                int matches = 0;
                for (int i = 0; i < pickedNumbers.Length; i++)
                {
                    for (int j = 0; j < pickedNumbers.Length; j++)
                    {
                        if (pickedNumbers[i] == winningNumbers[j])
                        {
                            matches++;
                        }

                    }
                }


                moneyWon = jackpot / winningNumbers.Length * matches;//Formula for calculating a prize
                moneyFormatted = string.Format("{0:C}", moneyWon);//adds comas and a dollar sign to the moneyWon

                //Displays the results
                Console.WriteLine("You guessed " + matches + " numbers correctly!");
                Console.WriteLine("You won " + moneyFormatted + "!");
                Console.WriteLine(" ");
                Console.WriteLine("Do you want to play again? (Type 'Yes' to start over)");

                answer = Console.ReadLine();
                if(answer.ToLower() != "yes")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Thanks for playing!");
                    isRunning = false;//used to exit the while statement
                }
                Console.WriteLine("");
            }
        }
    }
}
