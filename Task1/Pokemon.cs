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
        static void IncCount() => count++;

        /// <summary>
        /// Показывает количество созданных экземпляров
        /// </summary>
        public static void ShowCount() => OutputData.Message($"Количество созданных покемонов: {count}\n");

        #region Изменение характеристик 

        /// <summary>
        /// Увеличивает параметры покемона, если возможно, на переданные значения
        /// </summary>
        /// <param name="incAtk">Атака</param>
        /// <param name="incDef">Защита</param>
        /// <param name="incStam">Выносливость</param>
        /// <returns>Изменённый покемон</returns>
        public Pokemon IncreaseParameters(int incAtk, int incDef, int incStam)
        {
            IncreaseAttack(incAtk);
            IncreaseDefense(incDef);
            IncreaseStamina(incStam);
            return this;
        }

        /// <summary>
        /// Увеличивает параметры покемона, если возможно, на переданные значения
        /// </summary>
        /// <param name="p">Изменяемый покемон</param>
        /// <param name="incAtk">Атака</param>
        /// <param name="incDef">Защита</param>
        /// <param name="incStam">Выносливость</param>
        /// <returns>Изменённый покемон</returns>
        public static Pokemon IncreaseParameters(Pokemon p, int incAtk, int incDef, int incStam)
        {
            p.IncreaseParameters(incAtk, incDef, incStam);
            return p;
        }

        /// <summary>
        /// Увеличивает атаку покемона, если возможно
        /// </summary>
        /// <param name="increase">Увеличение</param>
        Pokemon IncreaseAttack(int increase)
        {
            attack = Math.Clamp(attack + increase, MIN_ATK, MAX_ATK);
            return this;
        }

        /// <summary>
        /// Увеличивает зашиту покемона, если возможно
        /// </summary>
        /// <param name="increase">Увеличение</param>
        Pokemon IncreaseDefense(int increase)
        {
            defense = Math.Clamp(defense + increase, MIN_DEF, MAX_DEF);
            return this;
        }

        /// <summary>
        /// Увеличивает выносливость покемона, если возможно
        /// </summary>
        /// <param name="increase">Увеличение</param>
        Pokemon IncreaseStamina(int increase)
        {
            stamina = Math.Clamp(stamina + increase, MIN_STAM, MAX_STAM);
            return this;
        }

        #endregion

        /// <summary>
        /// Считает мощность покемона
        /// </summary>
        /// <param name="atk">Атака покемона</param>
        /// <param name="def">Защита покемона</param>
        /// <param name="stam">Выносливость покемона</param>
        /// <returns>Число с округлением до сотых</returns>
        public double CalculatePower() => Math.Round(Math.Sqrt(defense) * Math.Sqrt(stamina) / 10 * attack, 2);

    }
}
