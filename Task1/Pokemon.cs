namespace Task
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

        int attack;
        int defense;
        int stamina;

        static uint Count { get; set; }

        /// <summary>
        /// Работа с атакой 
        /// </summary>
        public int Attack
        {
            get => attack;
            
            set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, MIN_ATK, "По условию атака");
                
                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MAX_ATK, "По условию атака");

                attack = value;   
            }
        }

        /// <summary>
        /// Работа с защитой
        /// </summary>
        public int Defense
        {
            get => defense;
            
            set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, MIN_DEF, "По условию защита");

                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MAX_DEF, "По условию защита");

                defense = value;
            }
        }

        /// <summary>
        /// Работа с выносливостью
        /// </summary>
        public int Stamina
        {
            get => stamina;
            
            set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, MIN_STAM, "По условию выносливость");

                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MAX_STAM, "По условию выносливость");

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

            Count++;
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

            Count++;
        }

        /// <summary>
        /// Копирование
        /// </summary>
        /// <param name="p">Копируемый экземпляр</param>
        public Pokemon(Pokemon p)
        {
            ArgumentNullException.ThrowIfNull(p, "Невозможно скопировать покемона по null");

            Attack = p.attack;
            Defense = p.defense;
            Stamina = p.stamina;

            Count++;
        }

        /// <summary>
        /// Конструктором с инициализатором
        /// </summary>
        /// <param name="atk">Атака покемона</param>
        public Pokemon(int atk) :this()
        {
            Attack = atk;
        }
        #endregion

        /// <summary>
        /// Печатает все характеристики покемона
        /// </summary>
        /// <param name="p">Конкретный покемон</param>
        public string Show() => $"Атака: {Attack,3}, защита: {Defense,3}, выносливость: {Stamina,3}\n";

        /// <summary>
        /// Показывает количество созданных экземпляров
        /// </summary>
        public static string ShowCount() => $"Количество созданных покемонов: {Count}\n";

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
        /// Увеличивает параметры покемона на переданные значения
        /// </summary>
        /// <param name="incAtk">Атака</param>
        /// <param name="incDef">Защита</param>
        /// <param name="incStam">Выносливость</param>
        /// <returns>Изменённый покемон</returns>
        public void IncreaseParameters(int incAtk, int incDef, int incStam)
        {
            IncreaseAttack(incAtk);
            IncreaseDefense(incDef);
            IncreaseStamina(incStam);
        }

        /// <summary>
        /// Увеличивает атаку покемона
        /// </summary>
        /// <param name="incAtk">Увеличение</param>
        void IncreaseAttack(int incAtk) => Attack = attack + incAtk;

        /// <summary>
        /// Увеличивает зашиту покемона
        /// </summary>
        /// <param name="incDef">Увеличение</param>
        void IncreaseDefense(int incDef) => Defense = defense + incDef;

        /// <summary>
        /// Увеличивает выносливость покемона, если возможно
        /// </summary>
        /// <param name="incStam">Увеличение</param>
        void IncreaseStamina(int incStam) => Stamina = stamina + incStam;
        #endregion

        /// <summary>
        /// Считает и возвращает мощность покемона
        /// </summary>
        /// <param name="p">Покемон</param>
        /// <returns>Мощность(округляя до 0,01)</returns>
        public static double operator ~(Pokemon p) => p.CalculatePower();

        /// <summary>
        /// Считает мощность покемона
        /// </summary>
        /// <returns>Число с округлением до сотых</returns>
        double CalculatePower() => Math.Round(Math.Sqrt(Defense) * Math.Sqrt(Stamina) / 10 * Attack, 2);

        /// <summary>
        /// Уменьшает выносливость покемона на 1
        /// </summary>
        /// <param name="p">Покемон, выносливость которого надо уменьшить</param>
        /// <returns>Изменённый покемон</returns>
        public static Pokemon operator --(Pokemon p)
        {
            Pokemon pokemon = new(p);
            pokemon.DecrementStamina();
            return pokemon;
        }
        
        /// <summary>
        /// Уменьшает выноливость на 1
        /// </summary>
        void DecrementStamina() => Stamina--;

        /// <summary>
        /// Считает сумму характеристик покемона 
        /// </summary>
        /// <param name="p">Покемон</param>
        public static explicit operator int (Pokemon p) => p.Sum(); // explicit - явное привидение

        /// <summary>
        /// Считает сумму характеристик покемона 
        /// </summary>
        /// <returns>Сумма характеристик</returns>
        int Sum() => Attack + Defense + Stamina;

        /// <summary>
        /// Увеличивает выносливость покемона на определённое число
        /// </summary>
        /// <param name="p">Покемон для увеличения</param>
        /// <param name="stam">Увеличение</param>
        /// <returns>Изменённый покемон</returns>
        public static Pokemon operator >>(Pokemon p, int stam)
        {
            Pokemon pokemon = new(p);
            pokemon.IncreaseStamina(stam);
            return pokemon;
        }

        /// <summary>
        /// Считает среднее характеристик покемона 
        /// </summary>
        /// <param name="p">Покемон</param>
        public static implicit operator double(Pokemon p) => p.Average(); // implicit - явное привидение

        /// <summary>
        /// Считает среднее характеристик покемона 
        /// </summary>
        /// <returns></returns>
        double Average() => Math.Round(Sum() / 3.0, 2);

        /// <summary>
        /// Увеличивает атаку покемона на заданное число
        /// </summary>
        /// <param name="p">Покемон</param>
        /// <param name="incAtk">Увеличение</param>
        /// <returns>Покемон с изменённой атакой атакой</returns>
        public static Pokemon operator <(Pokemon p, int incAtk)
        {
            Pokemon pokemon = new(p);
            pokemon.IncreaseAttack(incAtk);
            return pokemon;
        }

        /// <summary>
        /// Увеличивает атаку покемона на заданное число
        /// </summary>
        /// <param name="incAtk">Увеличение</param>
        /// <param name="p">Покемон</param>
        /// <returns>Покемон с изменённой атакой атакой</returns>
        public static Pokemon operator <(int incAtk, Pokemon p) => p < incAtk;

        /// <summary>
        /// Увеличивает защиту покемона на заданное число
        /// </summary>
        /// <param name="p">Покемон3</param>
        /// <param name="incDef">Увеличение защиты</param>
        /// <returns>Покемон с изменённой защитой</returns>
        public static Pokemon operator >(Pokemon p, int incDef)
        {
            Pokemon pokemon = new(p);
            pokemon.IncreaseDefense(incDef);
            return pokemon;
        }
        
        /// <summary>
        /// Увеличивает защиту покемона на заданное число
        /// </summary>
        /// <param name="incDef">Увеличение защиты</param>
        /// <param name="p">Покемон3</param>
        /// <returns>Покемон с изменённой защитой</returns>
        public static Pokemon operator >(int incDef, Pokemon p) => p > incDef;

        // TODO: Написать метод поиска моды выносливости покемонов по индексатору

    }
}
