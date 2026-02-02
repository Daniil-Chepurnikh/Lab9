namespace Task
{
    /// <summary>
    /// Коллекция покемонов
    /// </summary>
    internal class PokemonArray
    {
        Pokemon[] pokemons;

        /// <summary>
        /// Датчик случайных чисел
        /// </summary>
        static Random random = new();

        /// <summary>
        /// Инициализация по умолчанию
        /// </summary>
        public PokemonArray()
        {
            pokemons = [];
        }

        /// <summary>
        /// Инициализация случайными значениями элементов массива
        /// </summary>
        /// <param name="length">Длина массива</param>
        public PokemonArray(int length)
        {
            pokemons = new Pokemon[length];

            for (int p = 0; p < length; p++)
            {
                pokemons[p] = new(random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));
            }
        }

        /// <summary>
        /// Копирование
        /// </summary>
        /// <param name="pokemons">Копируемый массив</param>
        public PokemonArray(PokemonArray pokemons)
        {
            // TODO: Разобраться по материалам как сделать глубокое копирование
        }

        // TODO: Написать метод для просмотра элементов массива


    }
}
