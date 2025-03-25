using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame
{
    public class Game
    {
        private readonly int _targetNumber;
        private int _attempts;

        public Game(int? predefinedNumber = null)
        {
            _targetNumber = predefinedNumber ?? new Random().Next(1, 101);
            _attempts = 0;
        }

        public string MakeGuess(int guess)
        {
            _attempts++;
            if (guess < _targetNumber) return "Загадане число більше.";
            if (guess > _targetNumber) return "Загадане число менше.";
            return $"Вітаємо! Ви вгадали число {_targetNumber} за {_attempts} спроб.";
        }

        public int GetAttempts() => _attempts;
        public int GetTargetNumber() => _targetNumber;
    }
}
