// GoodPractice: ОТДЕЛЬНЫЙ КЛАСС - ОТДЕЛЬНЫЙ ФАЙЛ
// GoodPractice: Не пиши лишних/очевидных вещей
// GoodPractice: ровный вывод в консоль $"{значение, желаемая ширина}"
// GoodPractice: Ровные столбики в программном коде

namespace Task1
{
    /// <summary>
    /// Демонстрация работы программы
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Pokemon pokemon = new();
            pokemon.Show();

            Pokemon pokemon_1 = new(111, 111, 111);
            pokemon_1.Show();

            Pokemon pokemon_2 = new(pokemon_1);
            pokemon_2.Show();

            Pokemon.ShowCount();

            pokemon = Pokemon.IncreaseAttack(pokemon, 100);
            pokemon.Show();

            pokemon_1 = Pokemon.IncreaseDefense(pokemon_1, 100);
            pokemon_1.Show();

            pokemon_2 = Pokemon.IncreaseStamina(pokemon_2, 100);
            pokemon_2.Show();
        }
    }
}
