using Task;

namespace Testing
{
    [TestClass]
    public sealed class Test
    {
        #region Boundary Value Testing
        [TestMethod]
        public void TestCreatePokemonWithMinParameters()
        {
            Pokemon pokemon = new(Pokemon.MIN_ATK, Pokemon.MIN_DEF, Pokemon.MIN_STAM);

            Assert.AreEqual(Pokemon.MIN_ATK, pokemon.Attack);
            Assert.AreEqual(Pokemon.MIN_DEF, pokemon.Defense);
            Assert.AreEqual(Pokemon.MIN_STAM, pokemon.Stamina);
        }

        [TestMethod]
        public void TestCreatePokemonWithMinAttackLess()
        {
            string ooops = "";
            try
            {
                Pokemon pokemon = new(Pokemon.MIN_ATK - 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                ooops = "Слишком маленькая атака";
            }

            Assert.AreEqual("Слишком маленькая атака", ooops);
        }

        [TestMethod]
        public void TestCreatePokemonWithMinAttackGreater()
        {
            Pokemon pokemon = new(Pokemon.MIN_ATK + 1);

            Assert.AreEqual(Pokemon.MIN_ATK + 1, pokemon.Attack);
        }

        [TestMethod]
        public void TestCreatePokemonWithMinDefenseLess()
        {
            string ooops = string.Empty;
            try
            {
                Pokemon pokemon = new(299, Pokemon.MIN_DEF - 1, 111);
            }
            catch (ArgumentOutOfRangeException)
            {
                ooops = "Слишком малая защита";
            }

            Assert.AreEqual("Слишком малая защита", ooops);
        }

        [TestMethod]
        public void TestCreatePokemonWithMinDefenseGreater()
        {
            Pokemon pokemon = new(299, Pokemon.MIN_DEF + 1, 111);

            Assert.AreEqual(Pokemon.MIN_DEF + 1 , pokemon.Defense);
        }

        [TestMethod]
        public void TestCreatePokemonWithMinStaminaLess()
        {
            string ooops = string.Empty;
            try
            {
                Pokemon pokemon = new(299, 299, Pokemon.MIN_STAM - 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                ooops = "Слишком малая выносливость";
            }

            Assert.AreEqual("Слишком малая выносливость", ooops);
        }

        [TestMethod]
        public void TestCreatePokemonWithMinStaminaGreater()
        {
            Pokemon pokemon = new(299, 299, Pokemon.MIN_STAM + 1);

            Assert.AreEqual(Pokemon.MIN_STAM + 1, pokemon.Stamina);
        }

        [TestMethod]
        public void TestCreatePokemonWithMaxParameters()
        {
            Pokemon pokemon = new(Pokemon.MAX_ATK, Pokemon.MAX_DEF, Pokemon.MAX_STAM);

            Assert.AreEqual(Pokemon.MAX_ATK, pokemon.Attack);
            Assert.AreEqual(Pokemon.MAX_DEF, pokemon.Defense);
            Assert.AreEqual(Pokemon.MAX_STAM, pokemon.Stamina);
        }

        [TestMethod]
        public void TestCreatePokemonWithMaxStaminaLess()
        {
            Pokemon pokemon = new(299, 299, Pokemon.MAX_STAM - 1);

            Assert.AreEqual(Pokemon.MAX_STAM - 1, pokemon.Stamina);
        }

        [TestMethod]
        public void TestCreatePokemonWithMaxStaminaGreater()
        {
            char q = '-';
            try
            {
                Pokemon pokemon = new(299, 299, Pokemon.MAX_STAM + 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                q = '+';
            }
            
            Assert.AreEqual('+', q);
        }

        [TestMethod]
        public void TestCreatePokemonWithMaxDefenseLess()
        {
            Pokemon pokemon = new(299, Pokemon.MAX_DEF - 1, 299);

            Assert.AreEqual(Pokemon.MAX_DEF - 1, pokemon.Defense);
        }

        [TestMethod]
        public void TestCreatePokemonWithMaxDefenseGreater()
        {
            char q = '-';
            try
            {
                Pokemon pokemon = new(299, Pokemon.MAX_DEF + 1, 299);
            }
            catch (ArgumentOutOfRangeException)
            {
                q = '+';
            }

            Assert.AreEqual('+', q);
        }

        [TestMethod]
        public void TestCreatePokemonWithMaxAttackLess()
        {
            Pokemon pokemon = new(Pokemon.MAX_ATK - 1, 111, 299);

            Assert.AreEqual(Pokemon.MAX_ATK - 1, pokemon.Attack);
        }

        [TestMethod]
        public void TestCreatePokemonWithMaxAttackGreater()
        {
            char q = '-';
            try
            {
                Pokemon pokemon = new(Pokemon.MAX_ATK + 1, 111, 299);
            }
            catch (ArgumentOutOfRangeException)
            {
                q = '+';
            }

            Assert.AreEqual('+', q);
        }
        #endregion

        #region Тестирование Конструкторов
        [TestMethod]
        public void TestCreatePokemonWithAttackOnly()
        {
            Pokemon pokemon = new(299);

            Assert.AreEqual(299, pokemon.Attack);
            Assert.AreEqual(Pokemon.MIN_DEF, pokemon.Defense);
            Assert.AreEqual(Pokemon.MIN_STAM, pokemon.Stamina);
        }

        [TestMethod]
        public void TestCreatePokemonWithoutParameters()
        {
            Pokemon pokemon = new();

            Assert.AreEqual(Pokemon.MIN_ATK, pokemon.Attack);
            Assert.AreEqual(Pokemon.MIN_DEF, pokemon.Defense);
            Assert.AreEqual(Pokemon.MIN_STAM, pokemon.Stamina);
        }

        [TestMethod]
        public void TestCreatePokemonWithMidParameters()
        {
            Pokemon pokemon = new(222, 333, 444);

            Assert.AreEqual(222, pokemon.Attack);
            Assert.AreEqual(333, pokemon.Defense);
            Assert.AreEqual(444, pokemon.Stamina);
        }

        [TestMethod]
        public void TestCopyPokemon()
        {
            Pokemon pokemon = new(Pokemon.MIN_ATK, Pokemon.MIN_DEF, Pokemon.MIN_STAM);
            Pokemon copy    = new(pokemon);

            Assert.AreEqual(copy.Attack, pokemon.Attack);
            Assert.AreEqual(copy.Defense, pokemon.Defense);
            Assert.AreEqual(copy.Stamina, pokemon.Stamina);
        }

        [TestMethod]
        public void TestCopyNull()
        {
            char q = '+';
            try
            {
                Pokemon copy = new(null);
            }
            catch (ArgumentNullException)
            {
                q = '-';
            }
            Assert.AreEqual('-', q);
        }
        #endregion

    }
}
