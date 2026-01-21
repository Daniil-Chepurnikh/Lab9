// GoodPractice: ОТДЕЛЬНЫЙ КЛАСС - ОТДЕЛЬНЫЙ ФАЙЛ
// GoodPractice: Не пиши лишних/очевидных вещей
// GoodPractice: ровный вывод в консоль $"{значение, ширина}"
// GoodPractice: Ровные столбики в программном коде

using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pokemon.ShowCount();

            Pokemon Vanya = new();
            Vanya.Show();

            Pokemon Petya = new(111, 111, 111);
            Petya.Show();

            Pokemon Sidya = new(Petya);
            Sidya.Show();

            Pokemon.ShowCount();

            Vanya.IncreaseParameters(111, 222, 333);
            Pokemon.IncreaseParameters(Petya, 1, 1, 1);
            Sidya.IncreaseParameters(111, 222, 333);
            
            Vanya.Show();
            Petya.Show();
            Sidya.Show();

            OutputData.Message($"Мощность {nameof(Vanya)}: {~Vanya}\n"); // экспериментирую. сказано это делается при компиляции
        }
    }
}
