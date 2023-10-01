using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            //variables you can play around with.
            /////////////////////
            int numberMax = 20;//
            int numberMin = 1; // 
            int maxAttempt = 5;//                            
            /////////////////////

            Console.WriteLine("Välkommen! Jag tänker på ett nummer. \nKan du gissa vilket? \nDu får fem försök.");


            int number = 0;
            string userInput = "";
            int attempt = 0;
            int input = 0;
            bool userExit = false;

            void randomize()
            {
                number = random.Next(numberMin, numberMax);
            }

            randomize();

            bool CheckGuess(int i) //checks if the input is equal to the random generated number
            {


                if (i == number)
                {
                    Console.WriteLine("Wohoo! Du klarade det!");
                    return true;
                }
                else if (i == number + 1 || i == number - 1)
                {
                    Console.WriteLine("Riktigt nära!");
                    return false;
                }
                else if (i > number)
                {
                    Console.WriteLine("Tyvärr, du gissade för högt!");
                    return false;
                }
                else
                {
                    Console.WriteLine("Tyvärr, du gissade för lågt!");
                    return false;
                }

            }

            void maingame() //main code
            {
                while (attempt <= maxAttempt) //loops until it has reached maxAttempt
                {
                    userInput = Console.ReadLine();
                    Int32.TryParse(userInput, out input);
                    attempt++;

                    if (CheckGuess(input))
                    {
                        break;
                    }

                    if (attempt == maxAttempt)
                    {
                        Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!");
                        break;
                    }


                }
                while (userExit == false) //loops until user doesnt want to play anymore
                {
                    Console.WriteLine("Vill du spela igen?\nOm du vill spela igen skriv ja.\nOm du inte vill spela igen skriv nej.");
                    string userAnswer = Console.ReadLine();     

                    if (userAnswer == "ja" || userAnswer == "Ja")
                    {
                        Console.WriteLine("Kan du gissa vilket? \nDu får fem försök.");
                        attempt = 0;
                        randomize();
                        maingame();
                    }
                    else if (userAnswer == "nej" || userAnswer == "Nej")
                    {
                        Console.WriteLine("Okej, ha en trevlig dag!");
                        userExit = true;
                        break;
                    }
                }
            }
            maingame();


        }
    }
}
