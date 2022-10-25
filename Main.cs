using System;
using System.Linq;
using System.Collections.Generic;

namespace Game
{
    class MainClass
    {
        static void Main()
        {
            // object[] pokemons = new object[] { "Dracaufeau", 100, 100, 100, 100  };
            // object[,] pokemons = new object[,] { { "Dracaufeau", 100, 99, 98, 97 }, { "Pikacringe", 96, 95, 94, 93 }  };
            // List<Pokemon> pokemons = new List<Pokemon> { { "Dracaufeau", 100, 99, 98, 97 }, { "Pikacringe", 96, 95, 94, 93 }  };
            Pokemon test = new Pokemon("Salamalaise", 51, 50, 12, 20);
            Pokemon isse = new Pokemon("Pikacringe", 100, 50, 12, 20);
            Pokemon ahie = new Pokemon("hé mais il est cheaté lui", 201, 250, 200, 200);
            List<Pokemon> starterPack = new List<Pokemon> { test, isse, ahie };
            List<Pokemon> pokemons = new List<Pokemon> { test, isse };

            // Console.WriteLine($"what to do next?");
            Console.WriteLine($"t'as le choix entre :\n{starterPack[0].name} (1)\n{starterPack[1].name} (2)\n{starterPack[2].name} (3)\n--------------------------------------------------------");
            
            int ptDR = 0;
            foreach (var item in starterPack)
            {
                Actions.Stats(item);
                Console.WriteLine($"attrapez-le avec {++ptDR}\n--------------------------------------------------------");
                
            }
            // Console.WriteLine(pokemons[0].name);
            List<Pokemon> deck = new List<Pokemon> {  };
            // Console.WriteLine(operation switch
            // {            
            //     "1" => Actions.Attack(pokemons[0], pokemons[1]),
            //     "2" => Actions.Stats(pokemons[0]),
            //     _ => "Error"
            // });
            var operationN = int.Parse(Console.ReadLine());
            Pokemon choice = starterPack[operationN-1];
            Console.WriteLine($"you chose {choice.name}");
            

            while (choice.HP > 0)
            {
                Console.WriteLine($"tu peux: te fight avec 1, voir tes stats avec 2, te heal avec 3");
                string operation = Console.ReadLine();
                switch (operation)
                {
                    case "1":
                        // Console.WriteLine(Actions.Attack(pokemons[0], starterPack[2]));
                        Actions.Attack(choice,starterPack[2]);
                        Console.WriteLine(choice.HP);
                        break;
                    case "2":
                        Actions.Stats(choice);
                        break;
                    case "3":
                        Actions.Heal(choice);
                        break;
                    default:
                        return;
                };
                // operation switch
                // {            
                //     "1" => Actions.Attack(pokemons[0], pokemons[1]),
                //     "2" => Actions.Stats(pokemons[0]),
                //     _ => "Error"
                // };
            }
        }
    }
}