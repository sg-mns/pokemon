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
            if (defender.defense - attacker.attack < 0) defender.HP -= (attacker.attack - defender.defense);
            else defender.HP -= /* (defender.defense - attacker.attack) */ 2;
            
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

        public static void Stats(Pokemon pokemon)
        {
            Console.WriteLine($"\nname : {pokemon.name}\nhp : {Convert.ToInt32(pokemon.HP)}\ndamage : {pokemon.attack}\nattack : {pokemon.attack}\ndefense : {pokemon.defense}\nspeed : {pokemon.speed}");
        }

        public static void Heal(Pokemon pokemon, int potions, bool ingame)
        {
            if (pokemon.HP >= pokemon.totalHP) Console.WriteLine($"\nt déjà au max gros bouffon");
            // else
            // {
                // if (pokemon.HP >= pokemon.totalHP) pokemon.HP = pokemon.totalHP;
            else if (ingame)
                {
                    pokemon.HP += 0.3 * pokemon.totalHP;
                }
            else pokemon.HP = pokemon.totalHP;
            if (pokemon.HP >= pokemon.totalHP) pokemon.HP = pokemon.totalHP;
            // }
            --potions;
        }
        public static void Announcer()
        {
            Console.WriteLine($"vous allez combattre");
        }
    }
}