using Task;

namespace Testing;

// TODO: написать тесты массива покемонов

[TestClass]
public class TestPokemonArray
{
    #region “естирование конструкторов
    [TestMethod]
    public void TestCratePokemonArrayWithoutParameter()
    {
        PokemonArray pokemons = new();

        Assert.AreEqual(0, pokemons.Length);
    }

    [TestMethod]
    public void TestCopyNull()
    {
        bool isPassed = false;
        try
        {
            PokemonArray pokemons = new(null);
        }
        catch(ArgumentNullException)
        { 
            isPassed = true;
        }
        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestCopyCorrect()
    {
        PokemonArray pokemons = new(1);
        PokemonArray pikachus = new(pokemons);

        Assert.AreEqual(pikachus[0].Attack, pokemons[0].Attack);
        Assert.AreEqual(pikachus[0].Defense, pokemons[0].Defense);
        Assert.AreEqual(pikachus[0].Stamina, pokemons[0].Stamina);

        pokemons[0]--;

        Assert.AreNotEqual(pikachus[0].Stamina, pokemons[0].Stamina);
    }

    [TestMethod]
    public void TestCratePokemonArrayWithParameter()
    {
        PokemonArray pokemons = new(11);

        Assert.AreEqual(11, pokemons.Length);
    }
    #endregion

    #region “естирование индексатора
    [TestMethod]
    public void WriteIndexOutOfRange1()
    {
        PokemonArray pokemons = new(3);
        bool isPassed = false;
        try
        {
            pokemons[4] = new();
        }
        catch(IndexOutOfRangeException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void WriteIndexOutOfRange2()
    {
        PokemonArray pokemons = new(3);
        bool isPassed = false;
        try
        {
            pokemons[-1] = new();
        }
        catch (IndexOutOfRangeException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void ReadIndexOutOfRange1()
    {
        PokemonArray pokemons = new(3);
        bool isPassed = false;
        try
        {
           OutputData.Message(pokemons[4].Show());
        }
        catch (IndexOutOfRangeException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void ReadIndexOutOfRange2()
    {
        PokemonArray pokemons = new(3);
        bool isPassed = false;
        try
        {
            OutputData.Message(pokemons[-1].Show());
        }
        catch (IndexOutOfRangeException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void WriteCorrect1()
    {
        PokemonArray pokemons = new(4);
        
        pokemons[3] = new(111, 100, 99);

        Assert.AreEqual(111, pokemons[3].Attack);
        Assert.AreEqual(100, pokemons[3].Defense);
        Assert.AreEqual(99, pokemons[3].Stamina);
    }

    [TestMethod]
    public void WriteCorrect2()
    {
        PokemonArray pokemons = new(4);

        pokemons[0] = new(111, 100, 99);

        Assert.AreEqual(111, pokemons[0].Attack);
        Assert.AreEqual(100, pokemons[0].Defense);
        Assert.AreEqual(99, pokemons[0].Stamina);
    }

    [TestMethod]
    public void WriteCorrect3()
    {
        PokemonArray pokemons = new(4);

        pokemons[1] = new(111, 100, 99);

        Assert.AreEqual(111, pokemons[1].Attack);
        Assert.AreEqual(100, pokemons[1].Defense);
        Assert.AreEqual(99, pokemons[1].Stamina);
    }

    #endregion

}
