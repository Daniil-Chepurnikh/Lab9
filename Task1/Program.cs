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

            Pokemon petya = new(vanya);
            OutputData.Message(ConsoleColor.Magenta, $"{nameof(petya)} {petya.Show()}", $"{nameof(vanya)} {vanya.Show()}", $"Они равны: {petya.Equals(vanya)}");
            OutputData.Separetor();

            petya--;
            OutputData.Message(ConsoleColor.Magenta, $"{nameof(petya)} {petya.Show()}", $"{nameof(vanya)} {vanya.Show()}", $"Они равны: {petya.Equals(vanya)}");
            OutputData.Separetor();

            OutputData.Message(ConsoleColor.Magenta, $"{nameof(petya)}, {nameof(average)}", $"Они равны: {petya.Equals(average)}");
            OutputData.Separetor();

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
            
            var nextMode = FindStaminaMode(pokemons);
            OutputData.Message($"{nextMode}\n");

            //TODO: дополнить демонстрационную программу работой с массивом покемонов

            PokemonArray empty = new();
            try
            {
                empty[0] = new(111, 111, 111);
            }
            catch (ArgumentOutOfRangeException e)
            {
                OutputData.Error(e.Message);
            }

            try
            {
                OutputData.Message(empty[0].Show());
            }
            catch (ArgumentOutOfRangeException e)
            {
                OutputData.Error(e.Message);
            }

            PokemonArray copyPokemons = new(pokemons);
            OutputData.Message(ConsoleColor.Yellow, copyPokemons.Show());

            copyPokemons[10] = new(200, 222, 111);

            OutputData.Message(ConsoleColor.Magenta,  copyPokemons.Show());
            OutputData.Separetor();

            OutputData.Message(ConsoleColor.Green, pokemons.Show());
            OutputData.Separetor();

            OutputData.Message(pokemons[0].Show());
            OutputData.Separetor();
        }

        /// <summary>
        /// Нахдит моду выносливости покемонов
        /// </summary>
        /// <param name="collection">Массив покемонов для поиска моды</param>
        /// <returns></returns>
        static int FindStaminaMode(PokemonArray collection)
        {
            ArgumentNullException.ThrowIfNull(collection, "Невозможно искать моду в null");

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
                        mode      = nextMode;
                    }

                    nextMode      = collection[p].Stamina;
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
        private static void MergeSort(PokemonArray pokemons, int left, int right)
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
        private static void Merge(PokemonArray pokemons, int left, int mid, int right)
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
    }
}
