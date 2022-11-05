using System;

namespace Game
{
    public class Pokemon
    {
        // public Pokemon() {}
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
                pokemon.level +=1;
                pokemon.totalHP += 8;
                pokemon.HP = pokemon.totalHP;
                pokemon.attack += 2;
                pokemon.defense += 2;
                Console.WriteLine($"\nlevel up! you reached level {pokemon.level}\nnew stats: {pokemon.HP} HP\n{pokemon.attack} attack points\n{pokemon.defense} defense points");
                Console.WriteLine($"xp: {pokemon.xp}");
                pokemon.xp = 0/*  + (pokemon.xp - pokemon.requiredXp) */;
                pokemon.requiredXp += 15;
            }
        }
    }
    public class NPC : Pokemon
    {
        public NPC(string name, int totalHP, int speed, int attack, int defense) : base(name, totalHP, speed, attack, defense)
        {
        }

        public static NPC Generate()
        {
            List<string> name = new List<string> { "pee pee poo poo", "éclaté", "pourrave", "éclatax", "carrément nul", "tout pourri" };
            // string prout = "papa";
            int totalHP = Random.Shared.Next(8, 25);
            int speed = Random.Shared.Next(40, 60);
            int attack = Random.Shared.Next(8, 29);
            int defense = Random.Shared.Next(8, 25);
            // Console.WriteLine(name.ElementAt(Random.Shared.Next(name.Count())));
            
            return new NPC(name.ElementAt(Random.Shared.Next(name.Count())), totalHP, speed, attack, defense);
        }
        // public static void  test => Console.WriteLine(this.HP);
        
    }
}