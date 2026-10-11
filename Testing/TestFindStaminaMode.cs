using Task;
using Xunit;

namespace Testing;

public class TestFindStaminaMode
{
    [Fact]
    public void TestModeEmpty()
    {
        PokemonArray pokemons = new();
        bool isPassed = false;
        try
        {
            Program.FindStaminaMode(pokemons);
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.True(isPassed);
    }

    [Fact]
    public void TestModeNull()
    {
        bool isPassed = false;
        try
        {
            Program.FindStaminaMode(null);
        }
        catch (ArgumentNullException)
        {
            isPassed = true;
        }

        Assert.True(isPassed);
    }

    [Fact]
    public void TestModeOneElement()
    {

        PokemonArray pokemons = new(1);
        pokemons[0].Stamina = 111;

        int mode = Program.FindStaminaMode(pokemons);

        Assert.Equal(111, mode);
    }

    [Fact]
    public void TestModeManyElements()
    {
        PokemonArray pokemons = new(7);
        pokemons[0].Stamina = 120;
        pokemons[1].Stamina = 120;
        pokemons[2].Stamina = 117;
        pokemons[3].Stamina = 117;
        pokemons[4].Stamina = 120;
        pokemons[5].Stamina = 117;
        pokemons[6].Stamina = 120;

        int mode = Program.FindStaminaMode(pokemons);

        Assert.Equal(120, mode);
    }

    [Fact]
    public void TestModeManySortElements()
    {
        PokemonArray pokemons = new(7);
        pokemons[0].Stamina = 120;
        pokemons[1].Stamina = 120;
        pokemons[2].Stamina = 120;
        pokemons[3].Stamina = 121;
        pokemons[4].Stamina = 121;
        pokemons[5].Stamina = 122;
        pokemons[6].Stamina = 122;

        int mode = Program.FindStaminaMode(pokemons);

        Assert.Equal(120, mode);
    }
}
