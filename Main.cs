using System;
using System.Linq;
using System.Collections.Generic;

namespace Game
{
    class MainClass
    {
        static void Main()
        {
            List<string> logo = new List<string> {"                                  ,'\\", 
"    _.----.        ____         ,'  _\\   ___    ___     ____", 
"_,-'       `.     |    |  /`.   \\,-'    |   \\  /   |   |    \\  |`.", 
"\\      __    \\    '-.  | /   `.  ___    |    \\/    |   '-.   \\ |  |", 
" \\.    \\ \\   |  __  |  |/    ,','_  `.  |          | __  |    \\|  |", 
"   \\    \\/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |", 
"    \\     ,-'/  /   \\    ,'   | \\/ / ,`.|         /  /   \\  |     |", 
"     \\    \\ |   \\_/  |   `-.  \\    `'  /|  |    ||   \\_/  | |\\    |", 
"      \\    \\ \\      /       `-.`.___,-' |  |\\  /| \\      /  | |   |", 
"       \\    \\ `.__,'|  |`-._    `|      |__| \\/ |  `.__,'|  | |   |",  
"        \\_.-'       |__|    `-._ |              '-.|     '-.| |   |", 
"                                `'                            '-._|"};
foreach (var item in logo)
{
    Console.WriteLine(item);
    
}
            
            
            
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
            // Console.WriteLine($"t'as le choix entre :\n{starterPack[0].name} (1)\n{starterPack[1].name} (2)\n{starterPack[2].name} (3)\n--------------------------------------------------------");
            Console.WriteLine($"welcome to a pathetic ripoff of pokémon!\n\n--------------------------------------------------------");
            int potions = 10;
            int ptDR = 0;
            foreach (var item in starterPack)
            {
                Actions.Stats(item);
                Console.WriteLine($"pick him with {++ptDR}\n\n--------------------------------------------------------");
                
            }
            List<Playable> deck = new List<Playable> {  };
            // Console.WriteLine(operation switch
            // {            
            //     "1" => Actions.Attack(pokemons[0], pokemons[1]),
            //     "2" => Actions.Stats(pokemons[0]),
            //     _ => "Error"
            // });
            int operationN;
            while (true)
            {
                operationN = int.Parse(Console.ReadKey().KeyChar.ToString());
                try
                {
                    test = starterPack[operationN-1];
                    break;
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"\nthis pokémon does not exist!");
                }
            }
            Playable choice = starterPack[operationN-1];
            Console.WriteLine($"\nyou chose {choice.name}");
            // int  = 3;
            while (choice.HP > 0)
            {
                Console.WriteLine($"\nMain Menu | 1 - fight a random pokemon\nMain Menu | 2 - check your pokémon's stats\nMain Menu | 3 - heal entirely\nMain Menu | leave this trashy game with any other key");
                ConsoleKeyInfo operation = Console.ReadKey();
                switch (operation.Key)
                {
                    case ConsoleKey.D1:
                        // Console.WriteLine(Actions.Attack(pokemons[0], starterPack[2]));
                        // Random r = new Random();
                        // int fauneIndexRnd = Random.Shared.Next(faune.Count());
                        // Console.WriteLine(string.Join(", ", faune.Select(i => i.name.ToString()).ToArray()));
                        // int fauneIndexRnd = r.Next(faune.Count());
                        // NPC radis = faune.ElementAt(fauneIndexRnd);
                        NPC radis = NPC.Generate();
                        Console.WriteLine($"\nt'affrontes {radis.name}");
                        if (radis.speed >= choice.speed)
                        {
                            Actions.Attack(radis, choice);
                            Console.WriteLine($"\nVous êtes trop lent ! {radis.name} vous a infligé {choice.totalHP - choice.HP} points de dégâts!");
                        }
                        while (true && choice.HP > 0)
                        {
                            Console.WriteLine($"\nIn-game | 1 - attack {radis.name}\nIn-game | 2 - check your stats\nIn-game | 3 - use a potion\nIn-game | 4 - try to get the hell out of here\n");
                            ConsoleKeyInfo inGameOperation = Console.ReadKey();
                            bool fuite = false;
                            // bool ingame = true;
                            switch (inGameOperation.Key)
                            {
                                case ConsoleKey.D1:
                                    Actions.Attack(choice, radis);// radis.HP -= 8; 
                                    if (radis.HP>0) Console.WriteLine($"HP de {radis.name}: {radis.HP}/{radis.totalHP}");
                                    break;
                                case ConsoleKey.D2:
                                    Actions.Stats(choice);
                                    continue;
                                case ConsoleKey.D3:
                                    if (choice.HP >= choice.totalHP)
                                    {
                                        Console.WriteLine($"\nt déjà au max gros bouffon");
                                        continue;
                                    }
                                    else Actions.Heal(choice, potions, true);
                                    break;
                                case ConsoleKey.D4:
                                    int fuitest = Random.Shared.Next(100);
                                    Console.WriteLine(fuitest);
                                    
                                    if (fuitest>55)
                                    {
                                        fuite = true;
                                        Console.WriteLine($"\nmalaise la fuite le lâche");
                                    } else Console.WriteLine($"PTDR T A CHIER");
                                    
                                    break;
                                default:
                                    break;
                            }
                            if (radis.HP <= 0)
                            {
                                // ingame = false;
                                Console.WriteLine($"\ncongrats! you've beaten {radis.name}");
                                choice.xp += 14;
                                Playable.xpCheck(choice);
                                // choice.requiredXp += 15;
                                break;
                            }
                            else if (fuite) break;
                            else Actions.Attack(radis, choice);
                            // Console.WriteLine($"{radis.name} vous a infligé {choice.totalHP - choice.HP} points de dégâts!");
                        }
                        // Playable.xpCheck(choice);
                        // NPC radis = faune.OrderBy(x => r.NextDouble()).Take(1);
                        // while (choice.HP > 0 && faune[0].HP > 0)
                        // {
                            // if (list[0].speed >= list[1].speed)
                            // {

                            // }
                            // else Actions.Attack(radis,choice);
                        // }
                        // Actions.Attack(faune[0],choice);
                        // Console.WriteLine(/* Convert.ToInt32(choice.HP) */"ptdr LOL?");
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