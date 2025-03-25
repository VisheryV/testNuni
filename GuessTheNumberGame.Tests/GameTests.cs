using Xunit;
using GuessTheNumberGame;

namespace GuessTheNumberGame.Tests
{
    public class GameTests
    {
        // Тест 1: MakeGuess повертає повідомлення "Загадане число більше", коли введене число менше
        [Fact]
        public void MakeGuess_ReturnsHigherMessage_WhenGuessIsTooLow()
        {
            var game = new Game(50);
            string result = game.MakeGuess(30);
            Assert.Equal("Загадане число більше.", result);
        }

        // Тест 2: MakeGuess повертає повідомлення "Загадане число менше", коли введене число більше
        [Fact]
        public void MakeGuess_ReturnsLowerMessage_WhenGuessIsTooHigh()
        {
            var game = new Game(50);
            string result = game.MakeGuess(70);
            Assert.Equal("Загадане число менше.", result);
        }

        // Тест 3: MakeGuess повертає повідомлення про успіх, коли вгадано число
        [Fact]
        public void MakeGuess_ReturnsSuccessMessage_WhenGuessIsCorrect()
        {
            var game = new Game(50);
            string result = game.MakeGuess(50);
            Assert.StartsWith("Вітаємо!", result);
        }

        // Тест 4: Перевірка лічильника спроб після кількох введень
        [Fact]
        public void GetAttempts_IncrementsAfterEachGuess()
        {
            var game = new Game(50);
            game.MakeGuess(30);
            game.MakeGuess(40);
            Assert.Equal(2, game.GetAttempts());
        }

        // Тест 5: Перевірка, чи правильно повертається загадане число
        [Fact]
        public void GetTargetNumber_ReturnsCorrectNumber()
        {
            var game = new Game(42);
            Assert.Equal(42, game.GetTargetNumber());
        }

        // Тест 6: Перевірка, що кількість спроб не менша за 1
        [Fact]
        public void GetAttempts_AtLeastOneAttemptAfterFirstGuess()
        {
            var game = new Game(50);
            game.MakeGuess(30);
            Assert.True(game.GetAttempts() >= 1);
        }

        // Тест 7: Перевірка поведінки методу MakeGuess на кількох варіантах введення
        [Fact]
        public void MakeGuess_ReturnsCorrectMessages_ForMultipleGuesses()
        {
            var game = new Game(50);
            Assert.Equal("Загадане число більше.", game.MakeGuess(30));
            Assert.Equal("Загадане число менше.", game.MakeGuess(70));
            Assert.StartsWith("Вітаємо!", game.MakeGuess(50));
        }

        // Тест 8: Перевірка на неправильне введення
        [Fact]
        public void MakeGuess_ReturnsErrorMessage_WhenInputIsNotANumber()
        {
            var game = new Game(50);
            string result = game.MakeGuess(int.Parse("NaN")); 
            Assert.Equal("Будь ласка, введіть коректне число.", result);
        }

        // Тест 9: Перевірка на максимальне значення (100)
        [Fact]
        public void MakeGuess_ReturnsCorrectMessage_WhenGuessIs100()
        {
            var game = new Game(100);
            string result = game.MakeGuess(100);
            Assert.StartsWith("Вітаємо!", result);
        }

        // Тест 10: Перевірка на мінімальне значення (1)
        [Fact]
        public void MakeGuess_ReturnsCorrectMessage_WhenGuessIs1()
        {
            var game = new Game(1);
            string result = game.MakeGuess(1);
            Assert.StartsWith("Вітаємо!", result);
        }
    }
}
