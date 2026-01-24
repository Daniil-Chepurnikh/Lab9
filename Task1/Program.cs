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
            OutputData.Message(Pokemon.ShowCount());

            Pokemon Vanya = new();
            OutputData.Message($"{nameof(Vanya)} {Vanya.Show()}");

            Pokemon Petya = new(111, 111, 111);
            OutputData.Message($"{nameof(Petya)} {Petya.Show()}");

            Pokemon Sidya = new(Petya);
            OutputData.Message($"{nameof(Sidya)} {Sidya.Show()}");

            OutputData.Message(Pokemon.ShowCount());

            Vanya.IncreaseParameters(111, 222, 333);
            Pokemon.IncreaseParameters(Petya, 1, 1, 1);
            Sidya.IncreaseParameters(111, 222, 333);
            
            OutputData.Message($"{nameof(Vanya)} {Vanya.Show()}");
            OutputData.Message($"{nameof(Petya)} {Petya.Show()}");
            OutputData.Message($"{nameof(Sidya)} {Sidya.Show()}");

            OutputData.Message($"Мощность {nameof(Vanya)}: {~Vanya}\n"); // экспериментирую. сказано это делается при компиляции

            Petya = --Petya;
            OutputData.Message($"{nameof(Petya)} {Petya.Show()}");

            Sidya = Sidya >> 11;
            OutputData.Message($"{nameof(Sidya)} {Sidya.Show()}");

            OutputData.Message($"Сумма характеристик {nameof(Vanya)}: {(int)Vanya}\n");

            double average = Vanya;
            OutputData.Message($"Среднее характеристик {nameof(Vanya)}: {average}\n");

            Vanya = Vanya > 90;
            OutputData.Message($"{nameof(Vanya)} {Vanya.Show()}");
            Vanya = -90 > Vanya;
            OutputData.Message($"{nameof(Vanya)} {Vanya.Show()}");


            Vanya = Vanya < 90;
            OutputData.Message($"{nameof(Vanya)} {Vanya.Show()}");
            Vanya = -90 < Vanya;
            OutputData.Message($"{nameof(Vanya)} {Vanya.Show()}");

        }
    }
}
