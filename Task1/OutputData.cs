using System;

namespace Task1
{
    internal static class OutputData
    {
        /// <summary>
        /// Печатает ошибки
        /// </summary>
        /// <param name="error">Печатаемая ошибка</param>
        public static void Error(string error) => Message($"Ошибка: {error}!", ConsoleColor.Red);

        /// <summary>
        /// Печатаеn красивые сообщения
        /// </summary>
        /// <param name="message">Сообщение на печать</param>
        /// <param name="color">Цвет текста</param>
        public static void Message(string message = "Ввод корректен \n", ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        public static void Separetor() => Message("<===><=====><========><============>\n\n", ConsoleColor.DarkGreen);
    }
}
