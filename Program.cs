using System;

namespace GuessTheNumberGame
{
    class Program
    {
        static void Main()
        {
            var game = new Game();
            Console.WriteLine("Гра 'Вгадай число'! Введіть число від 1 до 100.");

            while (true)
            {
                Console.Write("Ваш варіант: ");
                if (int.TryParse(Console.ReadLine(), out int guess))
                {
                    string result = game.MakeGuess(guess);
                    Console.WriteLine(result);
                    if (result.StartsWith("Вітаємо!")) break;
                }
                else
                {
                    Console.WriteLine("Будь ласка, введіть коректне число.");
                }
            }
        }
    }
}
