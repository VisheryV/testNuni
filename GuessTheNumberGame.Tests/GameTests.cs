using Xunit;
using GuessTheNumberGame;

namespace GuessTheNumberGame.Tests
{
    public class GameTests
    {
        // ���� 1: MakeGuess ������� ����������� "�������� ����� �����", ���� ������� ����� �����
        [Fact]
        public void MakeGuess_ReturnsHigherMessage_WhenGuessIsTooLow()
        {
            var game = new Game(50);
            string result = game.MakeGuess(30);
            Assert.Equal("�������� ����� �����.", result);
        }

        // ���� 2: MakeGuess ������� ����������� "�������� ����� �����", ���� ������� ����� �����
        [Fact]
        public void MakeGuess_ReturnsLowerMessage_WhenGuessIsTooHigh()
        {
            var game = new Game(50);
            string result = game.MakeGuess(70);
            Assert.Equal("�������� ����� �����.", result);
        }

        // ���� 3: MakeGuess ������� ����������� ��� ����, ���� ������� �����
        [Fact]
        public void MakeGuess_ReturnsSuccessMessage_WhenGuessIsCorrect()
        {
            var game = new Game(50);
            string result = game.MakeGuess(50);
            Assert.StartsWith("³����!", result);
        }

        // ���� 4: �������� ��������� ����� ���� ������ �������
        [Fact]
        public void GetAttempts_IncrementsAfterEachGuess()
        {
            var game = new Game(50);
            game.MakeGuess(30);
            game.MakeGuess(40);
            Assert.Equal(2, game.GetAttempts());
        }

        // ���� 5: ��������, �� ��������� ����������� �������� �����
        [Fact]
        public void GetTargetNumber_ReturnsCorrectNumber()
        {
            var game = new Game(42);
            Assert.Equal(42, game.GetTargetNumber());
        }

        // ���� 6: ��������, �� ������� ����� �� ����� �� 1
        [Fact]
        public void GetAttempts_AtLeastOneAttemptAfterFirstGuess()
        {
            var game = new Game(50);
            game.MakeGuess(30);
            Assert.True(game.GetAttempts() >= 1);
        }

        // ���� 7: �������� �������� ������ MakeGuess �� ������ �������� ��������
        [Fact]
        public void MakeGuess_ReturnsCorrectMessages_ForMultipleGuesses()
        {
            var game = new Game(50);
            Assert.Equal("�������� ����� �����.", game.MakeGuess(30));
            Assert.Equal("�������� ����� �����.", game.MakeGuess(70));
            Assert.StartsWith("³����!", game.MakeGuess(50));
        }

        // ���� 8: �������� �� ����������� ��������
        [Fact]
        public void MakeGuess_ReturnsErrorMessage_WhenInputIsNotANumber()
        {
            var game = new Game(50);
            string result = game.MakeGuess(int.Parse("NaN")); 
            Assert.Equal("���� �����, ������ �������� �����.", result);
        }

        // ���� 9: �������� �� ����������� �������� (100)
        [Fact]
        public void MakeGuess_ReturnsCorrectMessage_WhenGuessIs100()
        {
            var game = new Game(100);
            string result = game.MakeGuess(100);
            Assert.StartsWith("³����!", result);
        }

        // ���� 10: �������� �� �������� �������� (1)
        [Fact]
        public void MakeGuess_ReturnsCorrectMessage_WhenGuessIs1()
        {
            var game = new Game(1);
            string result = game.MakeGuess(1);
            Assert.StartsWith("³����!", result);
        }
    }
}
