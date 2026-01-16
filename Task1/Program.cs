// GoodPractice: ОТДЕЛЬНЫЙ КЛАСС - ОТДЕЛЬНЫЙ ФАЙЛ
// GoodPractice: Не пиши лишних/очевидных вещей
// GoodPractice: ровный вывод в консоль $"{значение, ширина}"
// GoodPractice: Ровные столбики в программном коде

using System;

namespace Task1
{
    /// <summary>
    /// Демонстрация работы программы
    /// </summary>
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

            Pokemon.IncreaseAttack(Vanya, 100);
            Vanya.Show();

            Pokemon.IncreaseDefense(Petya, 100);
            Petya.Show();

            Pokemon.IncreaseStamina(Sidya, 100);
            Sidya.Show();

            Vanya.IncreaseAttack(111);  // Ваня, возьми меч поострее
            Vanya.IncreaseDefense(111); // Ваня, надень кольчугу покрепче
            Vanya.IncreaseStamina(111); // Ваня, возьми землицы русской
            Vanya.Show();               // Ваня, покажи этим супостатам

        }
    }
}
