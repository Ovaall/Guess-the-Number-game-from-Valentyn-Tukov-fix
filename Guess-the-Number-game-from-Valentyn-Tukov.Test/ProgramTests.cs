
using System;
using System.IO;
using Xunit;
using GuessTheNumberGameFromValentynTukov;


namespace Guess_the_Number_game_from_Valentyn_Tukov.Tes
{

    
    
    public class ProgramTests
    {


            [Fact]
            public void The1TestTheRandomNotLessThan1AndNotMoreThan100()
            {
                //Act

                for (int i = 0; i < 1000; i++)
                {
                    int repeatedResult = Program.MyRandom();
                    Assert.InRange(repeatedResult, 1, 100);
                }


            }

            [Fact]
            public void The2testTargetNumberNotLessThan1AndNotMoreThan100()
            {
                // Arrange
                int targetNumber;

                // Act
                targetNumber = Program.MyRandom();

                // Assert
                Assert.InRange(targetNumber, 1, 100);
            }


            [Fact]
            public void Test3TheAllAttemptsNotGreaterThan10()
            {
                // Act
                int allAttempts = Program.AllAttempts;

                // Assert
                Assert.True(allAttempts <= 10);
            }

            [Fact]
            public void TheTest4AttemptsNotGreaterThan10()

            {
                // Arrange
                int targetNumber = 42;
                int allAttempts = 10;

              using (StringReader sr = new StringReader("42\n"))
              using (StringWriter sw = new StringWriter())
              {
                TextReader originalInput = Console.In;

                Console.SetIn(sr);
                Console.SetOut(sw);

                // Act
                Program.PlayGame(targetNumber, allAttempts, Console.In, Console.Out);

                // Assert
                Assert.True(Program.Attempts <= allAttempts);

                Console.SetIn(originalInput);

                //  Console.SetIn(Console.In);
                //  Console.SetOut(Console.Out);
            }
            }

        


        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void TheTest4PositiveNumbers(int number)
        {
            // Assert
            Assert.True(number > 0);
        }


        [Theory]
        [InlineData("5")]
        [InlineData("10")]
        public void TheTest6InputIsNumber(string input)
        {
            // Act
            bool isNumber = int.TryParse(input, out _);

            // Assert
            Assert.True(isNumber);
        }


        [Theory]
        [InlineData("abc")]
        [InlineData("!@#")]
        public void TheTest7InputIsNotInvalidCharacter(string input)
        {
            // Act
            bool isNumber = int.TryParse(input, out _);

            // Assert
            Assert.False(isNumber);
        }


        [Fact]
        public void The8testPlayGameShouldEndWhenGuessIsCorrect()
        {
            // Arrange
            const int targetNumber = 42;
            const int maxAttempts = 10;

            using (StringReader fakeConsoleInput = new StringReader("42\n"))
            using (StringWriter fakeConsoleOutput = new StringWriter())
            {
                Console.SetIn(fakeConsoleInput);
                Console.SetOut(fakeConsoleOutput);
                //Console.SetIn(sr);
                //Console.SetOut(sw);

                // Act
                //Program.PlayGame(targetNumber, maxAttempts);
                Program.PlayGame(targetNumber, maxAttempts, Console.In, Console.Out);

                // Assert

                Assert.Contains($"Congratulations! You guessed the number 42 in 1 attempts.", fakeConsoleOutput.ToString());
            //    Assert.Contains($"Congratulations! You guessed the number 42 in 1 attempts.", sw.ToString());
            }
        }

    }
}
    