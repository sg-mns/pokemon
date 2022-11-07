namespace Game
{
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
}