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
            Console.WriteLine($"welcome to a pathetic ripoff of pokémon!\n\n--------------------------------------------------------");
            int potions = 5;
            int ptDR = 0;
            foreach (var item in starterPack)
            {
                Actions.Stats(item);
                Console.WriteLine($"pick him with {++ptDR}\n\n--------------------------------------------------------");
                
            }
            List<Playable> deck = new List<Playable> {  };
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
            Console.WriteLine($"\nyou've chosen {choice.name}");
            while (choice.HP > 0)
            {
                Console.WriteLine($"\nMain Menu | 1 - fight a random pokemon\nMain Menu | 2 - check your pokémon's stats\nMain Menu | 3 - heal entirely\nMain Menu | leave this trashy game with any other key");
                ConsoleKeyInfo operation = Console.ReadKey();
                switch (operation.Key)
                {
                    case ConsoleKey.D1:
                        NPC radis = NPC.Generate(choice.level);
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
                            switch (inGameOperation.Key)
                            {
                                case ConsoleKey.D1:
                                    Actions.Attack(choice, radis); 
                                    if (radis.HP>0) Console.WriteLine($"\nHP de {radis.name}: {radis.HP}/{radis.totalHP}");
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
                                    } else Console.WriteLine($"\nyour escaping attempt failed. :)");
                                    
                                    break;
                                default:
                                    break;
                            }
                            if (radis.HP <= 0)
                            {
                                Console.WriteLine($"\ncongrats! you've beaten {radis.name}");
                                choice.xp += 14;
                                Playable.xpCheck(choice);
                                potions = Actions.addPotion(potions);
                                break;
                            }
                            else if (fuite) break;
                            else Actions.Attack(radis, choice);
                        }
                        break;
                    case ConsoleKey.D2:
                        Actions.Stats(choice);
                        break;
                    case ConsoleKey.D3:
                        Actions.Heal(choice, potions, false);
                        break;
                    default:
                        return;
                };
            }
        Console.WriteLine($"GAME OVER T NUL");
        }
    }
}