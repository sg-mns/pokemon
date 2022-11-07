namespace Game
{
    public class NPC : Pokemon
    {
        public NPC(string name, int totalHP, int speed, int attack, int defense) : base(name, totalHP, speed, attack, defense)
        {
        }

        public static NPC Generate(int level)
        {
            List<string> name = new List<string> { "pee pee poo poo", "Magicarpe", "Ratata", "Taupiqueur", "Mewtwo", "Tortank", "Roucool", "Pikachu", "Artikodin" };
            int totalHP = (int)Math.Round(Random.Shared.Next(8, 25) + Random.Shared.Next(8, 25) * 0.1 * level, 0);
            int speed = Random.Shared.Next(40, 60);
            int attack = (int)Math.Round(Random.Shared.Next(8, 29) + Random.Shared.Next(8, 29) * 0.1 * level, 0);
            int defense = (int)Math.Round(Random.Shared.Next(8, 25) + Random.Shared.Next(8, 25) * 0.1 * level, 0);
            
            return new NPC(name.ElementAt(Random.Shared.Next(name.Count())), totalHP, speed, attack, defense);
        }       
    }
}