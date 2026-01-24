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
            OutputData.Separetor();
            
            Pokemon Vanya = new();
            OutputData.Message($"{nameof(Vanya)} {Vanya.Show()}");
            OutputData.Separetor();
            
            Pokemon Petya = new(111, 111, 111);
            OutputData.Message($"{nameof(Petya)} {Petya.Show()}");
            OutputData.Separetor();
            
            Pokemon Sidya = new(Petya);
            OutputData.Message($"{nameof(Sidya)} {Sidya.Show()}");
            OutputData.Separetor();
            
            OutputData.Message(Pokemon.ShowCount());
            OutputData.Separetor();
            
            Vanya.IncreaseParameters(111, 222, 333);
            Pokemon.IncreaseParameters(Petya, 1, 1, 1);
            Sidya.IncreaseParameters(111, 222, 333);
            
            OutputData.Message($"{nameof(Vanya)} {Vanya.Show()}");
            OutputData.Separetor();

            OutputData.Message($"{nameof(Petya)} {Petya.Show()}");
            OutputData.Separetor();

            OutputData.Message($"{nameof(Sidya)} {Sidya.Show()}");
            OutputData.Separetor();
            
            OutputData.Message($"Мощность {nameof(Vanya)}: {~Vanya}\n"); // экспериментирую. сказано это делается при компиляции
            OutputData.Separetor();
            
            Petya = --Petya;
            OutputData.Message($"{nameof(Petya)} {Petya.Show()}");
            OutputData.Separetor();
            
            Sidya = Sidya >> 11;
            OutputData.Message($"{nameof(Sidya)} {Sidya.Show()}");
            OutputData.Separetor();
            
            OutputData.Message($"Сумма характеристик {nameof(Vanya)}: {(int)Vanya}\n");
            
            double average = Vanya;
            OutputData.Message($"Среднее характеристик {nameof(Vanya)}: {average}\n");
            OutputData.Separetor();

            Vanya = Vanya > 90;
            OutputData.Message($"{nameof(Vanya)} {Vanya.Show()}");
            OutputData.Separetor();
            
            Vanya = -90 > Vanya;
            OutputData.Message($"{nameof(Vanya)} {Vanya.Show()}");
            OutputData.Separetor();

            Vanya = Vanya < 90;
            OutputData.Message($"{nameof(Vanya)} {Vanya.Show()}");
            OutputData.Separetor();

            Vanya = -90 < Vanya;
            OutputData.Message($"{nameof(Vanya)} {Vanya.Show()}");
            OutputData.Separetor();







        }
    }
}
