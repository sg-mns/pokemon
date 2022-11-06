using System;

namespace Game
{
    public class Actions
    {
        public static void Attack(Pokemon attacker, Pokemon defender)
        {
            if (defender.defense - attacker.attack < 0)
            {
                defender.HP -= (attacker.attack - defender.defense);
                if (attacker is NPC) Console.WriteLine($"\n{attacker.name} dealt {attacker.attack - defender.defense} damage points to your pokémon!");
                else Console.WriteLine($"\nyou dealt {attacker.attack - defender.defense} damage points to {defender.name}!");
            }
            else
            {
                var higDefAtk = Random.Shared.Next(1, 6);
                defender.HP -= higDefAtk;
                if (attacker is NPC)  Console.WriteLine($"\n{attacker.name} dealt {higDefAtk} damage points to your pokémon!");
                else Console.WriteLine($"\nyou dealt {higDefAtk} damage points to {defender.name}!");
            }
        }

        public static void Stats(Playable pokemon)
        {
            Console.WriteLine($"\nname : {pokemon.name}\nlvl : {pokemon.level}\nhp : {Convert.ToInt32(pokemon.HP)}/{Convert.ToInt32(pokemon.totalHP)}\ndamage : {pokemon.attack}\nattack : {pokemon.attack}\ndefense : {pokemon.defense}\nspeed : {pokemon.speed}\nxp : {Convert.ToInt32(pokemon.xp)}/{Convert.ToInt32(pokemon.requiredXp)}");
        }

        public static int Heal(Pokemon pokemon, int potions, bool ingame)
        {
            if (potions >= 1)
            {
                if (pokemon.HP >= pokemon.totalHP)
                {
                    Console.WriteLine($"\nyour HP are already maxed!");
                    return potions;
                }
                else if (ingame)
                    {
                        pokemon.HP += 0.4 * pokemon.totalHP;
                        if (pokemon.HP >= pokemon.totalHP) pokemon.HP = pokemon.totalHP;
                        Console.WriteLine($"\nyou used a potion! {potions} left.");
                        return --potions;
                    }
                else pokemon.HP = pokemon.totalHP;
            }
            else Console.WriteLine($"\nno more potions left. you're on your own now :)");
            return potions;
        }
        public static int addPotion(int potions)
        {
            var toast = Random.Shared.Next(1, 10);
            if (toast >= 9 && potions <= 6)
            {
                Console.WriteLine($"you found a potion!");
                return ++potions;
            }
            else return potions;
        }
        // public static void Announcer(params Pokemon[] list)
        // {
        //     string statsPlayer = "({list[0].totalHP}]HP - {list[0].totalHP} ATK - {list[0].totalHP} DEF)";
        //     string statsNPC = "({list[1].totalHP} HP - {list[1].attack} ATK - {list[1].defense} DEF)";
        //     if (list[0].name.Length >= statsNPC.Length)
        //     {

        //     }
        //     Console.WriteLine();
        // }
    }
}