using System;

namespace Game
{
    public class Actions
    {
        public static void Attack(Pokemon attacker, Pokemon defender)
        // public static void Attack(params Pokemon[] list)
        {
            // while (list[0].HP > 0 && list[1].HP > 0)
                
            // if (attacker.speed >= defender.speed)
            // if (defender.speed >= defender.speed)
            //     {
            // defender.HP -= 20;
            //     }
                // for (int i = 0; i < 2; i++)
                // foreach (var item in list)
                // {
                //     Console.WriteLine($"\n{--item.HP}");
                //     // item.HP -= 20;
                // }
                
                //     Console.WriteLine($"\nc au tour de {list[i].name}");
                //     if (list[i] is Playable)
                //     {
                //         Console.WriteLine($"tu veux faire quoi à part feur");
                //         string decision = Console.ReadLine();
                //         switch (decision)
                //         {
                //             case "bah rien":
                //                 Console.WriteLine($" :) ");
                //                 break;
                //         }
                //     } else {
                //         list[i].HP -= 
                //     }
                //     list[0].HP -= 20;
                    
                    
                // }
            if (defender.defense - attacker.attack < 0)
            {
                defender.HP -= (attacker.attack - defender.defense);
                if (attacker is NPC) Console.WriteLine($"\n{attacker.name} vous a infligé {attacker.attack - defender.defense} points de dégâts!");
            }
            else
            {
                defender.HP -= 2;
                if (attacker is NPC)  Console.WriteLine($"\n{attacker.name} vous a infligé 2 points de dégâts!");
                
            }  /* (defender.defense - attacker.attack) */ 
            
            // pokemon1.HP -= (pokemon1.defense - pokemon2.attack);
            // if (pokemon2.HP <= 0) return 0;
            // else return pokemon2.HP;
            // if (pokemon2.HP <= 0)
            // {
                // pokemon2.HP = 0;
                // Console.WriteLine($"\nbravo t'as éclaté cette grosse merde de {pokemon2.name}");
            // else return pokemon2.HP;
            // }

        }

        public static void Stats(Playable pokemon)
        {
            Console.WriteLine($"\nname : {pokemon.name}\nlvl : {pokemon.level}\nhp : {Convert.ToInt32(pokemon.HP)}/{Convert.ToInt32(pokemon.totalHP)}\ndamage : {pokemon.attack}\nattack : {pokemon.attack}\ndefense : {pokemon.defense}\nspeed : {pokemon.speed}\nxp : {Convert.ToInt32(pokemon.xp)}/{Convert.ToInt32(pokemon.requiredXp)}");
        }

        public static void Heal(Pokemon pokemon, int potions, bool ingame)
        {
            if (potions < 1)
            {
                if (pokemon.HP >= pokemon.totalHP)
                {
                    Console.WriteLine($"\nt déjà au max gros bouffon");
                    // return 0;
                }
                // else
                // {
                    // if (pokemon.HP >= pokemon.totalHP) pokemon.HP = pokemon.totalHP;
                else if (ingame)
                    {
                        pokemon.HP += 0.3 * pokemon.totalHP;
                        // return 1;
                    }
                else pokemon.HP = pokemon.totalHP;
                if (pokemon.HP >= pokemon.totalHP)
                {
                    pokemon.HP = pokemon.totalHP;
                }
                Console.WriteLine($"{potions}");
                --potions;
            }
            else Console.WriteLine($"pas de potions :)");
            
        }
        public static void addPotion(int potions)
        {
            var toast = Random.Shared.Next(1, 10);
            if (toast >= 8)
            {
                potions++;
                Console.WriteLine($"you found a potion!");
            }
        }
        // public static void Announcer()
        // {
        //     Console.WriteLine($"vous allez combattre");
        // }
    }
}