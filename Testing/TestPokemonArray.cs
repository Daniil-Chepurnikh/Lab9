using Task;

namespace Testing;

// написать тесты массива покемонов

[TestClass]
public class TestPokemonArray
{
    [TestMethod]
    public void TestCratePokemonArrayWithoutParameters()
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

    #region Тестирование индексатора
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





    #endregion

}
