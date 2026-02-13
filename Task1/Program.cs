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
            OutputData.Separator();
            
            vanya >>= 11;
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separator();

            vanya = vanya > 190;
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separator();
            
            vanya = -90 > vanya;
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separator();

            vanya = vanya < 190;
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separator();

            vanya = -90 < vanya;
            OutputData.Message($"{nameof(vanya)} {vanya.Show()}");
            OutputData.Separator();

            double average = vanya;
            OutputData.Message($"Сумма характеристик {nameof(vanya)}: {(int)vanya}\n");
            OutputData.Message($"Мощность {nameof(vanya)}: {~vanya}\n");
            OutputData.Message($"Среднее характеристик {nameof(vanya)}: {average}\n");
            OutputData.Separator();

            Pokemon petya = new(vanya);
            OutputData.Message(ConsoleColor.Magenta, $"{nameof(petya)} {petya.Show()}", $"{nameof(vanya)} {vanya.Show()}", $"Они равны: {petya.Equals(vanya)}");
            OutputData.Separator();

            petya--;
            OutputData.Message(ConsoleColor.Magenta, $"{nameof(petya)} {petya.Show()}", $"{nameof(vanya)} {vanya.Show()}", $"Они равны: {petya.Equals(vanya)}");
            OutputData.Separator();

            OutputData.Message(ConsoleColor.Magenta, $"{nameof(petya)}, {nameof(average)}", $"Они равны: {petya.Equals(average)}");
            OutputData.Separator();

            try
            {
                vanya.Equals(null);
            }
            catch(ArgumentNullException e)
            {
                OutputData.Error(e.Message);
            }
            
            PokemonArray pokemons = new(11);
            OutputData.Message(ConsoleColor.White, pokemons.Show());
            
            var mode = FindStaminaMode(pokemons);
            OutputData.Message($"{mode}\n");

            PokemonArray empty = new();
            try
            {
                empty[0] = new(111, 111, 111);
            }
            catch (IndexOutOfRangeException e)
            {
                OutputData.Error(e.Message);
            }

            try
            {
                OutputData.Message(empty[0].Show());
            }
            catch (IndexOutOfRangeException e)
            {
                OutputData.Error(e.Message);
            }

            PokemonArray copyPokemons = new(pokemons);
            OutputData.Message(ConsoleColor.Yellow, copyPokemons.Show());

            copyPokemons[10] = new(200, 222, 111);

            OutputData.Message(ConsoleColor.Magenta,  copyPokemons.Show());
            OutputData.Separator();

            OutputData.Message(ConsoleColor.Green, pokemons.Show());
            OutputData.Separator();

            OutputData.Message(pokemons[0].Show());
            OutputData.Separator();

            PokemonArray packmans = new(5);
            OutputData.Message(ConsoleColor.Blue, packmans.Show());

            try
            {
                PokemonArray array = MakePokemonArray(null);
                OutputData.Message(ConsoleColor.Blue, array.Show());
            }
            catch (ArgumentNullException e)
            {
                OutputData.Error(e.Message); 
            }

            OutputData.Separator();

            try
            {
                int staminaMode = FindStaminaMode(empty);
            }
            catch (ArgumentException e)
            {
                OutputData.Error(e.Message);
            }

            OutputData.Message($"Создано коллекций покемонов: {PokemonArray.CollectionCount}\n");
            OutputData.Message($"Создано покемонов: {Pokemon.Count}\n");
        }

        /// <summary>
        /// Нахдит моду выносливости покемонов
        /// </summary>
        /// <param name="collection">Массив покемонов для поиска моды</param>
        /// <returns></returns>
        public static int FindStaminaMode(PokemonArray collection)
        {
            ArgumentNullException.ThrowIfNull(collection, "Невозможно искать моду в null!");

            if (collection.Length == 0)
                throw new ArgumentException("Невозможно искать моду в пустом массиве!");
            
            MergeSort(collection, 0, collection.Length - 1);

            int mode = -1;
            var nextMode = collection[0].Stamina;
            var nextModeCount = 1;
            var modeCount = -1;

            for (int p = 1; p < collection.Length; p++)
            {
                if (nextMode == collection[p].Stamina)
                {
                    nextModeCount++;
                }
                else
                {
                    if (nextModeCount >  modeCount)
                    {
                        modeCount = nextModeCount;
                        mode = nextMode;
                    }

                    nextMode = collection[p].Stamina;
                    nextModeCount = 1;
                }
            }

            if (nextModeCount > modeCount)
                mode = nextMode;
            return mode;
        }

        /// <summary>
        /// Сортировка слиянием
        /// </summary>
        /// <param name="pokemons">Сортируемый массив</param>
        /// <param name="left">Левая граница сортируемого массива(не обязательно нуль)</param>
        /// <param name="right">Правая граница сортируемого массива(не обязательно длина без единицы)</param>
        static void MergeSort(PokemonArray pokemons, int left, int right)
        {
            if (left < right)
            {
                var mid = left + (right - left) / 2;
                MergeSort(pokemons, left, mid); // сортируем левый подмассив
                MergeSort(pokemons, mid + 1, right); // сортируем правый подмассив
                Merge(pokemons, left, mid, right); // сливаем два отсортированных подмассива
            }
        }

        /// <summary>
        /// Сливает отсортированные подмассивы
        /// </summary>
        /// <param name="pokemons">Массив в котором были сливаемые подмассивы</param>
        /// <param name="left">Левая граница(не всегда нуль)</param>
        /// <param name="mid">Середина массива от лефт до райт</param>
        /// <param name="right">Правая граница(не всегда настоящая правая)</param>
        static void Merge(PokemonArray pokemons, int left, int mid, int right)
        {
            var leftCounter = left; // счётчик по левому подмассиву
            var rightCounter = mid + 1; // счётчик по правому подмассиву
            Pokemon[] sortedArray = new Pokemon[right - left + 1]; // массив в который будем вписывать элементы в нужном порядке, его длина это буквально сколько между лефт и райт элементов
            var sortedArrayCounter = 0;

            while (leftCounter <= mid && rightCounter <= right) // чтобы чужим индексом не влезть в не свой подмассив
            {
                if (pokemons[leftCounter].Stamina <= pokemons[rightCounter].Stamina)
                    sortedArray[sortedArrayCounter++] = pokemons[leftCounter++];
                else
                    sortedArray[sortedArrayCounter++] = pokemons[rightCounter++];
            }

            while (leftCounter <= mid) // оставшиеся большие в левом подмассиве вписываем последними
            {
                sortedArray[sortedArrayCounter++] = pokemons[leftCounter++];
            }
            while (rightCounter <= right) // оставшиеся большие в правом подмассиве вписываем последними
            {
                sortedArray[sortedArrayCounter++] = pokemons[rightCounter++];
            }
            for (int p = 0; p < sortedArray.Length; p++) // записываем в правильном порядке в нужное место исходного массива(left + p, как раз из-за того что left не всегда будет нулём)
            {
                pokemons[left + p] = sortedArray[p];
            }
        }

        /// <summary>
        /// Заполняет массив покемонов вручную
        /// </summary>
        /// <param name="pokemons">Заполняемый массив</param>
        /// <returns>Заполненный массив</returns>
        static PokemonArray MakePokemonArray(PokemonArray pokemons)
        {
            ArgumentNullException.ThrowIfNull(pokemons);
            
            for (int p = 0; p < pokemons.Length; p++)
            {
                pokemons[p].Attack = InputData.IntNumber("Введите атаку покемона: ", InputData.RANGE_ERROR);
                pokemons[p].Defense = InputData.IntNumber("Введите защиту покемона: ", InputData.RANGE_ERROR);
                pokemons[p].Stamina = InputData.IntNumber("Введите выносливость покемона: ", InputData.RANGE_ERROR);
            }
            return pokemons;
        }
    }
}
