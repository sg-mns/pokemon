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
            Playable test = new Playable("Salamalaise", 51, 50, 12, 20);
            Playable isse = new Playable("Pikacringe", 100, 50, 12, 20);
            Playable ahie = new Playable("hé mais il est cheaté lui", 201, 250, 200, 200);
            List<Playable> starterPack = new List<Playable> { test, isse, ahie };

            NPC grosseMerde1 = new NPC("éclaté", 10, 5, 5, 2);
            NPC grosseMerde2 = new NPC("pourrave", 10, 5, 5, 2);
            NPC grosseMerde3 = new NPC("éclatax", 10, 5, 5, 2);
            NPC grosseMerde4 = new NPC("carrément nul", 2, 0, 1, 1);
            NPC grosseMerde5 = new NPC("tout pourri", 10, 5, 5, 2);
            List<NPC> faune = new List<NPC> { grosseMerde1, grosseMerde2, grosseMerde3, grosseMerde4, grosseMerde5 };
            // List<Pokemon> pokemons = new List<Pokemon> { test, isse };
            // starterPack.Remove(grosseMerde5);
            // test(grosseMerde1);
            Console.WriteLine($"t'as le choix entre :\n{starterPack[0].name} (1)\n{starterPack[1].name} (2)\n{starterPack[2].name} (3)\n--------------------------------------------------------");
            int potions = 5;
            int ptDR = 0;
            foreach (var item in starterPack)
            {
                Actions.Stats(item);
                Console.WriteLine($"attrapez-le avec {++ptDR}\n--------------------------------------------------------");
                
            }
            List<Playable> deck = new List<Playable> {  };
            // Console.WriteLine(operation switch
            // {            
            //     "1" => Actions.Attack(pokemons[0], pokemons[1]),
            //     "2" => Actions.Stats(pokemons[0]),
            //     _ => "Error"
            // });
            var operationN = int.Parse(Console.ReadLine());
            Playable choice = starterPack[operationN-1];
            Console.WriteLine($"you chose {choice.name}");
            // int  = 3;
            while (choice.HP > 0)
            {
                Console.WriteLine($"\nMENU | tu peux: fight un random avec 1, voir tes stats avec 2, te heal entièrement avec 3, quitter ce jeu merdique avec n'importe quelle autre touche");
                ConsoleKeyInfo operation = Console.ReadKey();
                switch (operation.Key)
                {
                    case ConsoleKey.D1:
                        // Console.WriteLine(Actions.Attack(pokemons[0], starterPack[2]));
                        Random r = new Random();
                        // Console.WriteLine(string.Join(", ", faune.Select(i => i.name.ToString()).ToArray()));
                        int fauneIndexRnd = r.Next(faune.Count());
                        NPC radis = faune.ElementAt(fauneIndexRnd);
                        Console.WriteLine($"\nt'affrontes {radis.name}");
                        while (true)
                        {
                            Console.WriteLine($"\ntu peux: attaquer {radis.name} avec 1, voir tes stats avec 2, te heal avec 3, tenter de te barre avec 4");
                            ConsoleKeyInfo inGameOperation = Console.ReadKey();
                            bool fuite = false;
                            // bool ingame = true;
                            switch (inGameOperation.Key)
                            {
                                case ConsoleKey.D1:
                                    radis.HP -= 8;
                                    if (radis.HP>0) Console.WriteLine($"HP de {radis.name}: {radis.HP}/{radis.totalHP}");
                                    
                                    break;
                                case ConsoleKey.D2:
                                    Actions.Stats(choice);
                                    break;
                                case ConsoleKey.D3:
                                    Actions.Heal(choice, potions, true);
                                    break;
                                case ConsoleKey.D4:
                                    fuite = true;
                                    Console.WriteLine($"\nmalaise la fuite le lâche");
                                    break;
                                default:
                                    break;
                            }
                            if (radis.HP <= 0 || fuite)
                            {
                                // ingame = false;
                                Console.WriteLine($"bravo t'as battu {radis.name}");
                                choice.xp += 14;
                                break;
                            }
                            else Actions.Attack(radis, choice);
                            Console.WriteLine($"{radis.name} vous a infligé {choice.totalHP - choice.HP} points de dégâts!");
                        }
                        // NPC radis = faune.OrderBy(x => r.NextDouble()).Take(1);
                        // while (choice.HP > 0 && faune[0].HP > 0)
                        // {
                            // if (list[0].speed >= list[1].speed)
                            // {

                            // }
                            // else Actions.Attack(radis,choice);
                        // }
                        // Actions.Attack(faune[0],choice);
                        Console.WriteLine(Convert.ToInt32(choice.HP));
                        break;
                    case ConsoleKey.D2:
                        Actions.Stats(choice);
                        break;
                    case ConsoleKey.D3:
                        Actions.Heal(choice, potions, false);
                        // Actions.Heal(choice, 3);
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
        Console.WriteLine($"GAME OVER T NUL");
        }
    }
}