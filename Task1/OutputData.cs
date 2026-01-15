using System;

namespace Task1
{
    internal static class OutputData
    {
        /// <summary>
        /// Печатает ошибки
        /// </summary>
        /// <param name="error">Печатаемая ошибка</param>
        public static void Error(string error = "Введено недопустимое значение")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: " + error + '!');
            Console.ResetColor();
        }

        /// <summary>
        /// Печатаеn красивые сообщения
        /// </summary>
        /// <param name="message">Сообщение на печать</param>
        /// <param name="color">Цвет печать</param>
        public static void Message(string message = "Ввод корректен \n", ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
