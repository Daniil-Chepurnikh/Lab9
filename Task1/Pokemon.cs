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
        public Pokemon(Pokemon pokemon)
        {
            attack = pokemon.attack;
            defense = pokemon.defense;
            stamina = pokemon.stamina;

            IncCount();
        }

        #endregion

        /// <summary>
        /// Печатает все характеристики покемона
        /// </summary>
        /// <param name="p">Конкретный покемон</param>
        public void Show() => OutputData.Message($"Атака: {attack,3}, защита: {defense,3}, выносливость: {stamina,3}\n");

        /// <summary>
        /// Увеличивает счётчик созданных экземпляров
        /// </summary>
        void IncCount() => count++;

        /// <summary>
        /// Показывает количество созданных экземпляров
        /// </summary>
        public static void ShowCount() => OutputData.Message($"Количество созданных покемонов:  {count}\n");

        #region Изменение характеристик 

        /// <summary>
        /// Увеличивает атаку покемона, если возможно
        /// </summary>
        /// <param name="pokemon">Покемон</param>
        /// <param name="increase">Увеличение</param>
        public static Pokemon IncreaseAttack(Pokemon pokemon, int increase)
        {
            var isCorrect = ValidateIncrease(pokemon.stamina, increase, MAX_STAM);
            if (isCorrect)
                pokemon.attack += increase;
            else
                OutputData.Error("Превышено максимальное значение выносливости");

            return pokemon;
        }

        /// <summary>
        /// Увеличивает зашиту покемона, если возможно
        /// </summary>
        /// <param name="pokemon">Покемон</param>
        /// <param name="increase">Увеличение</param>
        public static Pokemon IncreaseDefense(Pokemon pokemon, int increase)
        {
            var isCorrect = ValidateIncrease(pokemon.stamina, increase, MAX_STAM);
            if (isCorrect)
                pokemon.defense += increase;
            else
                OutputData.Error("Превышено максимальное значение выносливости");

            return pokemon;
        }

        /// <summary>
        /// Увеличивает выносливость покемона, если возможно
        /// </summary>
        /// <param name="pokemon">Покемон</param>
        /// <param name="increase">Увеличение</param>
        public static Pokemon IncreaseStamina(Pokemon pokemon, int increase)
        {
            var isCorrect = ValidateIncrease(pokemon.stamina, increase, MAX_STAM);
            if (isCorrect)
                pokemon.stamina += increase;
            else
                OutputData.Error("Превышено максимальное значение выносливости");

            return pokemon;
        }
        
        /// <summary>
        /// Проверяет возможность увеличения характеристики
        /// </summary>
        /// <param name="current">Текущее значение</param>
        /// <param name="max">Верхняя граница характеристики</param>
        /// <returns></returns>
        static bool ValidateIncrease(int current, int increase, int max) =>  current + increase <= max;

        #endregion
    }
}
