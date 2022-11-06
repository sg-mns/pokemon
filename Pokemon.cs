using System;

namespace Game
{
    public class Pokemon
    {
        public string name { get; set; }
        public int totalHP { get; set; }
        public double HP { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int speed { get; set; }

        public Pokemon(string name, int totalHP, int speed, int attack, int defense)
        {
            this.name = name;
            this.totalHP = totalHP;
            this.speed = speed;
            this.attack = attack;
            this.defense = defense;
            this.HP = totalHP;
        }
    }    
    public class Playable : Pokemon
    {
        public int xp {get; set;}
        public int requiredXp {get; set;}
        public int level {get; set;}

        public Playable(string name, int totalHP, int speed, int attack, int defense) : base(name, totalHP, speed, attack, defense)
        {
            this.xp = 0;
            this.requiredXp = 0;
            this.level = 1;
        }
        public static void xpCheck(Playable pokemon)
        {
            if (pokemon.xp >= pokemon.requiredXp)
            {
                pokemon.level += 1;
                pokemon.totalHP += 8;
                pokemon.HP = pokemon.totalHP;
                pokemon.attack += 3;
                pokemon.defense += 3;
                Console.WriteLine($"\nlevel up! you've reached level {pokemon.level}\nnew stats: {pokemon.HP} HP\n{pokemon.attack} attack points\n{pokemon.defense} defense points");
                pokemon.xp = 0 + (pokemon.xp - pokemon.requiredXp);
                pokemon.requiredXp += 8 * pokemon.level;
                Console.WriteLine($"xp required to reach the next level: {pokemon.xp}/{pokemon.requiredXp}");
            }
        }
    }
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