using System;

namespace Task1
{
    public class Pokemon
    {
        #region Диапазон значений

        const short MIN_ATK = 17;
        const short MAX_ATK = 414;

        const short MIN_DEF = 32;
        const short MAX_DEF = 396;

        const short MIN_STAM = 1;
        const short MAX_STAM = 496;

        #endregion

        static uint count = 0;

        int attack;
        int defense;
        int stamina;

        #region Конструкторы

        /// <summary>
        /// Инициализация минимальными возможными значениями
        /// </summary>
        public Pokemon()
        {
            attack  = MIN_ATK;
            defense = MIN_DEF;
            stamina = MIN_STAM;

            IncCount();
        }

        /// <summary>
        /// Инициализация желаемыми значениями
        /// </summary>
        /// <param name="atk">Атака</param>
        /// <param name="def">Защита</param>
        /// <param name="stam">Выносливость</param>
        public Pokemon(int atk, int def, int stam)
        {
            attack = atk;
            defense = def;
            stamina = stam;

            IncCount();
        }

        /// <summary>
        /// Копирование
        /// </summary>
        /// <param name="p">Копируемый экземпляр</param>
        public Pokemon(Pokemon p)
        {
            attack = p.attack;
            defense = p.defense;
            stamina = p.stamina;

            IncCount();
        }

        #endregion

        /// <summary>
        /// Печатает все характеристики покемона
        /// </summary>
        /// <param name="p">Конкретный покемон</param>
        public void Show() => OutputData.Message($"Атака: {attack,3}, защита: {defense,3}, выносливость: {stamina,3}");

        /// <summary>
        /// Увеличивает счётчик созданных экземпляров
        /// </summary>
        void IncCount() => count++;

        /// <summary>
        /// Показывает количество созданных экземпляров
        /// </summary>
        public static void ShowCount() => OutputData.Message("Количество созданных покемонов: " + count);

        static void IncreaseAttack(int increase)
        {
            
        }

        
        static void IncreaseDefense(int increase)
        {

        }

        
        static void IncreaseStamina(int increase)
        {

        }

        
        static int ValidateIncrease(int current, int min, int max)
        {
            int increase = InputData.InputAndValidateInt(min, max, "Введите увеличение");
            return (increase + current) <= max ? increase : 0;
        }

    }
}
