using System;

namespace Task
{
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
            // TODO: Разобраться по материалам как сделать конструктор без параметров
        }

        /// <summary>
        /// Инициализация случайными значениями элементов массива
        /// </summary>
        /// <param name="length">Длина массива</param>
        public PokemonArray(int length)
        {
            // TODO: Разобраться по материалам как заполнять элементы случайными числами
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
