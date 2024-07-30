using Models.Characters;

namespace Models.Tests
{
    public static class Extensions
    {
        public static void LevelUpTo(this Character character, int levels)
        {
            for (int i = 1; i < levels; i++)
                character.LevelUp();
        }
    }
}
