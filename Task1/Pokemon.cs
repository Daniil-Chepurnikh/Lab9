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

        public int Attack
        {
            get => attack;
            set
            {
                if (value < MIN_ATK)
                    attack = MIN_ATK;
                else if (value > MAX_ATK)
                    attack = MAX_ATK;
                else 
                    attack = value;
            }
        }

        public int Defense
        {
            get => defense;
            set
            {
                if (value < MIN_DEF)
                    defense = MIN_DEF;
                else if (value > MAX_DEF)
                    defense = MAX_DEF;
                else
                    defense = value;
            }
        }

        public int Stamina
        {
            get => stamina;
            set
            {
                if (value < MIN_STAM)
                    stamina = MIN_STAM;
                else if (value > MAX_STAM)
                    stamina = MAX_STAM;
                else
                    stamina = value;
            }
        }

        #region Конструкторы
        /// <summary>
        /// Инициализация минимальными возможными значениями
        /// </summary>
        public Pokemon()
        {
            Attack  = MIN_ATK;
            Defense = MIN_DEF;
            Stamina = MIN_STAM;

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
            Attack = atk;
            Defense = def;
            Stamina = stam;

            IncCount();
        }

        /// <summary>
        /// Копирование
        /// </summary>
        /// <param name="p">Копируемый экземпляр</param>
        public Pokemon(Pokemon p)
        {
            Attack = p.attack;
            Defense = p.defense;
            Stamina = p.stamina;

            IncCount();
        }
        #endregion

        /// <summary>
        /// Печатает все характеристики покемона
        /// </summary>
        /// <param name="p">Конкретный покемон</param>
        public void Show() => OutputData.Message($"Атака: {Attack,3}, защита: {Defense,3}, выносливость: {Stamina,3}\n");

        /// <summary>
        /// Увеличивает счётчик созданных экземпляров
        /// </summary>
        static void IncCount() => count++;

        /// <summary>
        /// Показывает количество созданных экземпляров
        /// </summary>
        public static void ShowCount() => OutputData.Message($"Количество созданных покемонов: {count}\n");

        #region Увеличение параметров
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
        /// Увеличивает атаку покемона, если возможно
        /// </summary>
        /// <param name="increase">Увеличение</param>
        Pokemon IncreaseAttack(int increase)
        {
            Attack = attack + increase;
            return this;
        }

        /// <summary>
        /// Увеличивает зашиту покемона, если возможно
        /// </summary>
        /// <param name="increase">Увеличение</param>
        Pokemon IncreaseDefense(int increase)
        {
            Defense = defense + increase;
            return this;
        }

        /// <summary>
        /// Увеличивает выносливость покемона, если возможно
        /// </summary>
        /// <param name="increase">Увеличение</param>
        Pokemon IncreaseStamina(int increase)
        {
            Stamina = stamina + increase;
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
        public double CalculatePower() => Math.Round(Math.Sqrt(Defense) * Math.Sqrt(Stamina) / 10 * Attack, 2);

    }
}
