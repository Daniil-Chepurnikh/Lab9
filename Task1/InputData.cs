using System;

namespace Task1
{
    internal static class InputData
    {
        const string OUT_OF_RANGE = "Число не входит в разрешённый дипазон";
        const string NOT_INTEGER = "Введено не целое число";

        /// <summary>
        /// Читает целое число
        /// </summary>
        /// <param name="message">Приглашение к вводу</param>
        /// <param name="error">Ошибка ввода</param>
        /// <returns>Число</returns>
        static int InputInt(string message, string error)
        {
            bool isCorrect;
            int number;
            do
            {
                OutputData.Message(message);
                isCorrect = int.TryParse(Console.ReadLine(), out number);

                if (!isCorrect)
                {
                    OutputData.Error(error);
                }

            } while (!isCorrect);
            return number;
        }

        /// <summary>
        /// Прверяет принадлежность диапазону
        /// </summary>
        /// <param name="min">Левая граница диапазона</param>
        /// <param name="max">Правая граница диапазона</param>
        /// <param name="number">Проверяемое число</param>
        /// <returns>true если принадлежит</returns>
        static bool ValidateNumber(int min, int max, int number) => number >= min && number <= max;

        /// <summary>
        /// Читает корректное целое число в необходимом диапазоне
        /// </summary>
        /// <param name="min">Левая граница диапазона</param>
        /// <param name="max">Правая граница диапазона</param>
        /// <param name="message">Приглашение к вводу</param>
        /// <returns>Число</returns>
        public static int InputAndValidateNumber(int min, int max, string message = "Введите целое число")
        {
            var isValid = true;
            int number;
            do
            {
                OutputData.Message(message);

                number = InputInt(message, NOT_INTEGER);
                if(!ValidateNumber(number, min, max))
                {
                    OutputData.Error(OUT_OF_RANGE);
                    isValid = false;
                }

            } while(!isValid);
            return number;
        }
    }
}
