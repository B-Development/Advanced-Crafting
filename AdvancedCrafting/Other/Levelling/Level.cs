namespace AdvancedCrafting.Other.Levelling
{
    public class Level
    {
        public string LevelName { get; set; }

        public string LevelExpNeeded { get; set; }

        public Level()
        {

        }

        public Level(string levelname, string levelexpneeded)
        {
            LevelName = levelname;
            LevelExpNeeded = levelexpneeded;
        }
    }
}
