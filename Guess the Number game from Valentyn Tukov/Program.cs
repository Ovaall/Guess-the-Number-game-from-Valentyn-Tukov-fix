
using System;

namespace GuessTheNumberGameFromValentynTukov
{
    public class Program
    {

        public static int Attempts { get; private set; } = 0;
        public static int AllAttempts { get; } = 10;

        public static int MyRandom()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }

        public static void PlayGame(int targetNumber, int allAttempts, TextReader inputReader, TextWriter outputWriter)
        {
          

            Attempts = 0;

            while (Attempts <= allAttempts)
            {
                Attempts++;

                outputWriter.WriteLine($"It is your {Attempts} attempt. Type the number and press ENTER");

                if (!int.TryParse(inputReader.ReadLine(), out int number) || number <= 0)
                {
                    outputWriter.WriteLine("Invalid input. Please enter a valid integer.");

                    Attempts--;
                    continue;
                }

                if (number == targetNumber)
                {
                    outputWriter.WriteLine($"Congratulations! You guessed the number {targetNumber} in {Attempts} attempts.");
                    break;
                }
                else if (number < targetNumber)
                {
                    outputWriter.WriteLine("Your guess is too low. You may try again!");
                }
                else
                {
                    outputWriter.WriteLine("Your guess is too high. You may try again!");
                }
            }

            if (Attempts == allAttempts)
            {
                outputWriter.WriteLine($"Sorry, you have used all {allAttempts} attempts. The guess number was {targetNumber}");
            }
        }

        public static void Main(string[] args)
        {
       

            Console.WriteLine("Hi, this is the Guess the Number game!");
            Console.WriteLine("A number from 1 to 100 inclusive was guessed. You have 10 attempts. Try to guess the number!");

            int targetNumber = MyRandom();

            PlayGame(targetNumber, 10, Console.In, Console.Out);

            Console.ReadLine();
        }

        
    }
}





