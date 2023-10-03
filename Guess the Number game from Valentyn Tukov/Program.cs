using System;

    namespace GuessTheNumberGameFromValentynTukov
{
        class Program
    { 
        static int MyRandom() 
        {
            
        Random random = new Random();
        return random.Next(1, 101);

        }
    
        static void Main(string[] args)
        {

            Console.WriteLine("Hi, this is the Guess the Number game!");
            Console.WriteLine("A number from 1 to 100 inclusive was guessed. You have 10 attempts. Try to guess the number!");

            
            int attempts = 0;
            int allAttempts = 10;
           
            int targetNumber = MyRandom();  
            while (attempts < allAttempts)
            {
               

                attempts ++;

                Console.WriteLine("It is your " + attempts + " attemtsw. Type the number and press the ENTER");

                
                if (!int.TryParse(Console.ReadLine(), out int number)) // inputs verification for been numbers.
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");

                    attempts--;
                    continue;
                }

                if (number == targetNumber)
                {
                    Console.WriteLine($"Congratulations! You guessed the number {targetNumber} in {attempts} attempts.");
                    break;
                }
                else if (number < targetNumber)
                {
                    Console.WriteLine("Your guess is too low. You may try again!");
                }
                else
                {
                    Console.WriteLine("Your guess is too high. You may try again!");
                }
            }

            if (attempts == allAttempts)
            {
                Console.WriteLine($"Sorry, you have all {allAttempts} The guess number was {targetNumber}");
            }
            Console.ReadLine(); 
        }
    }
   

  
}
