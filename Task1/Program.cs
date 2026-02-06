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
            Pokemon vanya = new(111, 111, 111);
            
            vanya = --vanya;
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separetor();
            
            vanya >>= 11;
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separetor();

            vanya = vanya > 190;
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separetor();
            
            vanya = -90 > vanya;
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separetor();

            vanya = vanya < 190;
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separetor();

            vanya = -90 < vanya;
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separetor();

            double average = vanya;
            OutputData.Message($"Сумма характеристик {nameof(vanya)}: {(int)vanya}\n");
            OutputData.Message($"Мощность {nameof(vanya)}: {~vanya}\n");
            OutputData.Message($"Среднее характеристик {nameof(vanya)}: {average}\n");
            OutputData.Separetor();

            //PokemonArray pokemons = new(11);
            //OutputData.Message(ConsoleColor.White, pokemons.Show());
        }

        ///// <summary>
        ///// Нахдит моду выносливости покемонов
        ///// </summary>
        ///// <param name="collection">Массив покемонов для поиска моды</param>
        ///// <returns></returns>
        //static int FindStaminaMode(PokemonArray collection)
        //{
          //TODO: написать
        //}

    }
}
