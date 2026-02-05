// GoodPractice: ОТДЕЛЬНЫЙ КЛАСС - ОТДЕЛЬНЫЙ ФАЙЛ
// GoodPractice: Не пиши лишних/очевидных вещей
// GoodPractice: ровный вывод в консоль $"{значение, ширина}"
// GoodPractice: Ровные столбики в программном коде

using System;

namespace Task
{
    /// <summary>
    /// Демонстрационная программа
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            OutputData.Message($"Создано покемонов: {Pokemon.Count}\n");
            OutputData.Separetor();

            Pokemon sanya = new(399);
            OutputData.Message($"{nameof(sanya)} {sanya.Show()}");
            OutputData.Separetor();

            Pokemon vanya = new();
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separetor();
            
            Pokemon petya = new(99, 99, 99);
            OutputData.Message($"{nameof(petya)} {petya.Show()}");
            OutputData.Separetor();
            
            Pokemon sidya = new(petya);
            OutputData.Message($"{nameof(sidya)} {sidya.Show()}");
            OutputData.Separetor();
            
            OutputData.Message($"Создано покемонов: {Pokemon.Count}\n");
            OutputData.Separetor();
            
            vanya.IncreaseStats(111, 222, 333);
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separetor();

            Pokemon.IncreaseStats(petya, 1, 1, 1);
            OutputData.Message($"{nameof(petya)} {petya.Show()}");
            OutputData.Separetor();

            try
            {
                sidya.IncreaseStats(1000, 222, 333);
            }
            catch (ArgumentOutOfRangeException e)
            {
                OutputData.Error(e.Message);
            }
            OutputData.Message($"{nameof(sidya)} {sidya.Show()}");
            OutputData.Separetor();
            
            OutputData.Message($"Мощность {nameof(vanya)}: {~vanya}\n");
            OutputData.Separetor();
            
            petya = --petya;
            OutputData.Message($"{nameof(petya)} {petya.Show()}");
            OutputData.Separetor();
            
            sidya >>= 11;
            OutputData.Message($"{nameof(sidya)} {sidya.Show()}");
            OutputData.Separetor();
            
            OutputData.Message($"Сумма характеристик {nameof(vanya)}: {(int)vanya}\n");
            
            double average = vanya;
            OutputData.Message($"Среднее характеристик {nameof(vanya)}: {average}\n");
            OutputData.Separetor();

            vanya = vanya > 90;
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separetor();
            
            vanya = -90 > vanya;
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separetor();

            vanya = vanya < 90;
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separetor();

            vanya = -90 < vanya;
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separetor();

            try
            {
                Pokemon oooops = new(null);
            }
            catch (ArgumentNullException e)
            {
                OutputData.Error(e.Message);
            }

            try
            {
                Pokemon oooops = new(16, 111, 111);
            }
            catch (ArgumentOutOfRangeException e)
            {
                OutputData.Error(e.Message);
            }

            try
            {
                Pokemon oooops = new(111, 31, 111);
            }
            catch (ArgumentOutOfRangeException e)
            {
                OutputData.Error(e.Message);
            }

            try
            {
                Pokemon oooops = new(111, 111, 0);
            }
            catch (ArgumentOutOfRangeException e)
            {
                OutputData.Error(e.Message);
            }

            PokemonArray pokemons = new(11);
            OutputData.Message(ConsoleColor.White, pokemons.Show());



        }

        /// <summary>
        /// Нахдит моду выносливости покемонов
        /// </summary>
        /// <param name="collection">Массив покемонов для поиска моды</param>
        /// <returns></returns>
        static int FindStaminaMode(PokemonArray collection)
        {
            //TODO: написать
        }

    }
}
