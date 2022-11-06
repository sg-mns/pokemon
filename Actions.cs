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
                if (attacker is NPC) Console.WriteLine($"\n{attacker.name} vous a infligé {attacker.attack - defender.defense} points de dégâts!");
                else Console.WriteLine($"\nyou dealt {attacker.attack - defender.defense} damage points to {defender.name}!");
            }
            else
            {
                var higDefAtk = Random.Shared.Next(1, 6);
                defender.HP -= higDefAtk;
                if (attacker is NPC)  Console.WriteLine($"\n{attacker.name} vous a infligé {higDefAtk} points de dégâts!");
                else Console.WriteLine($"\nyou dealt {higDefAtk} damage points to {defender.name}!");
            }
        }

        public static void Stats(Playable pokemon)
        {
            Console.WriteLine($"\nname : {pokemon.name}\nlvl : {pokemon.level}\nhp : {Convert.ToInt32(pokemon.HP)}/{Convert.ToInt32(pokemon.totalHP)}\ndamage : {pokemon.attack}\nattack : {pokemon.attack}\ndefense : {pokemon.defense}\nspeed : {pokemon.speed}\nxp : {Convert.ToInt32(pokemon.xp)}/{Convert.ToInt32(pokemon.requiredXp)}");
        }

        public static void Heal(Pokemon pokemon, int potions, bool ingame)
        {
            if (potions > 1)
            {
                if (pokemon.HP >= pokemon.totalHP)
                {
                    Console.WriteLine($"\nyour HP are already maxed!");
                }
                else if (ingame)
                    {
                        pokemon.HP += 0.3 * pokemon.totalHP;
                        potions -= 1;
                    }
                else pokemon.HP = pokemon.totalHP;
                if (pokemon.HP >= pokemon.totalHP)
                {
                    pokemon.HP = pokemon.totalHP;
                }
            }
            else Console.WriteLine($"pas de potions :)");
            
        }
        public static int addPotion(int potions)
        {
            var toast = Random.Shared.Next(1, 10);
            if (toast >= 8)
            {
                Console.WriteLine($"you found a potion!");
                return ++potions;
            }
            else return potions;
        }
    }
}