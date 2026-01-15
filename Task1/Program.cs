// GoodPractice: ОТДЕЛЬНЫЙ КЛАСС - ОТДЕЛЬНЫЙ ФАЙЛ
// GoodPractice: Не пиши лишних/очевидных вещей

namespace Task1
{
    /// <summary>
    /// Демонстрация работы программы
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Pokemon pokemon   = new();
            //Pokemon pokemon_1 = new(111, 111, 111);
            //Pokemon pokemon_2 = new(pokemon_1);

            pokemon.Show();
            //pokemon_1.Show();
            //pokemon_2.Show();
        }
    }
}
