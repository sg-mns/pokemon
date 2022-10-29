using System;

namespace Game
{
    public class Actions
    {
        public static void Attack(Pokemon pokemon1, Pokemon pokemon2)
        {
            if (pokemon2.defense - pokemon1.attack < 0) pokemon2.HP += (pokemon2.defense - pokemon1.attack);
            else pokemon2.HP -= (pokemon2.defense - pokemon1.attack);
            
            // pokemon1.HP -= (pokemon1.defense - pokemon2.attack);
            // if (pokemon2.HP <= 0) return 0;
            // else return pokemon2.HP;
            if (pokemon2.HP <= 0)
            {
                pokemon2.HP = 0;
                Console.WriteLine($"brave t'as éclaté cette grosse merde de {pokemon2.name}");
            // else return pokemon2.HP;
            }

        }

        public static void Stats(Pokemon pokemon)
        {
            Console.WriteLine($"name : {pokemon.name}\nhp : {Convert.ToInt32(pokemon.HP)}\ndamage : {pokemon.attack}\nattack : {pokemon.attack}\ndefense : {pokemon.defense}\nspeed : {pokemon.speed}");
        }

        public static void Heal(Pokemon pokemon, int potions)
        {
            if (pokemon.HP >= pokemon.totalHP) Console.WriteLine($"t déjà au max gros bouffon");
            // else
            // {
                // if (pokemon.HP >= pokemon.totalHP) pokemon.HP = pokemon.totalHP;
            else pokemon.HP += 0.3 * pokemon.totalHP;
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