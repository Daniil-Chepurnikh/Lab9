namespace Task
{
    /// <summary>
    /// Коллекция покемонов
    /// </summary>
    internal class PokemonArray
    {
        Pokemon[] pokemons;

        public Pokemon this[int index]
        {
            get 
            {  
                if (IsInRange(index, 0, pokemons.Length))
                    return pokemons[index];
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            set
            {
                if (IsInRange(index, 0, pokemons.Length))
                    pokemons[index] = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        /// <summary>
        /// Проверяет попадание числа в диапазон
        /// </summary>
        /// <param name="index">Проверяемое число</param>
        /// <param name="min">Левая граница диапазона(включительно)</param>
        /// <param name="max">Правая граница диапазона(НЕ включительно)</param>
        /// <returns>true если в диапазоне иначе false</returns>
        bool IsInRange(int index, int min, int max) => index >= min && index < max;

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
            ArgumentNullException.ThrowIfNull(pokemons, "Невозможно скопировать по null");
        }

        /// <summary>
        /// 
        /// </summary>
        public string Show()
        {
            foreach (var p in pokemons)
            {
                p.Show();
            }
        }
    }
}
