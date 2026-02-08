using System;

namespace Task
{
    /// <summary>
    /// Обратная связь пользователю
    /// </summary>
    static internal class OutputData
    {
        /// <summary>
        /// Печатает ошибки
        /// </summary>
        /// <param name="error">Печатаемая ошибка</param>
        public static void Error(string error) => Message($"Ошибка: {error}!\n", ConsoleColor.Red);

        /// <summary>
        /// Печатает красивые сообщения
        /// </summary>
        /// <param name="message">Сообщение на печать</param>
        /// <param name="color">Цвет текста</param>
        public static void Message(string message = "Ввод корректен \n", ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Печатает строки
        /// </summary>
        /// <param name="color">Цвет печати</param>
        /// <param name="messages">Массив строк</param>
        public static void Message(ConsoleColor color = ConsoleColor.White, params string[] messages)
        {
            Console.ForegroundColor = color;
            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Печатает разделители
        /// </summary>
        public static void Separetor() => Message("<===><=====><========><============>\n\n", ConsoleColor.DarkGreen);
    }
}
