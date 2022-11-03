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

        public Playable(string name, int totalHP, int speed, int attack, int defense) : base(name, totalHP, speed, attack, defense)
        {
            this.xp = 0;
        }
    }
    public class NPC : Pokemon
    {
        public NPC(string name, int totalHP, int speed, int attack, int defense) : base(name, totalHP, speed, attack, defense)
        {
        }
        // public static void  test => Console.WriteLine(this.HP);
        
    }
}