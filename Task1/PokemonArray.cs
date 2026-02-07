namespace Task
{
    /// <summary>
    /// Коллекция покемонов
    /// </summary>
    internal class PokemonArray
    {
        Pokemon[] pokemons;

        /// <summary>
        /// Количество созданных коллекций покемонов
        /// </summary>
        public static int collectionCount { get; private set; }

        public int Length => pokemons.Length;

        public Pokemon this[int index]
        {
            get 
            {  
                if (IsInRange(index, 0, Length))
                    return pokemons[index];
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            set
            {
                if (IsInRange(index, 0, Length))
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
            collectionCount++;
        }

        /// <summary>
        /// Инициализация случайными значениями элементов массива
        /// </summary>
        /// <param name="length">Длина массива</param>
        public PokemonArray(int length)
        {
            pokemons = new Pokemon[length];

            // TODO: сделать возможность самостоятельного ввода значений

            for (int p = 0; p < length; p++)
            {
                pokemons[p] = new(random.Next(111, 150), random.Next(111, 150), random.Next(111, 150));
            }
            collectionCount++;
        }

        /// <summary>
        /// Глубокое копирование
        /// </summary>
        /// <param name="source">Копируемый массив</param>
        public PokemonArray(PokemonArray source)
        {
            ArgumentNullException.ThrowIfNull(source, "Невозможно скопировать по null");

            pokemons = new Pokemon[source.Length];
            for (int p = 0; p < pokemons.Length; p++)
            {
                pokemons[p] = new(source[p]);
            }
        }

        /// <summary>
        /// Передаёт информацию о покемонах в массиве
        /// </summary>
        public string[] Show()
        {
            string[] messages = new string[pokemons.Length];

            for (int p = 0; p < Length; p++)
            {
                messages[p] = pokemons[p].Show();
            }
            return messages;
        }
    }
}
