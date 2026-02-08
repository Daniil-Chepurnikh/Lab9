using System;

namespace Task
{
    public static class InputData
    {
        public const string RANGE_ERROR = "Не введено число в разрешённом диапазоне";

        public static int IntNumber(string message, string error)
        {
            bool isCorrect;
            int number;
            do
            {
                OutputData.Message(message);
                isCorrect = int.TryParse(Console.ReadLine(), out number);

                if (!isCorrect)
                    OutputData.Error(error);

            } while (!isCorrect);
            return number;
        }
    }
}
