using System;
using System.Linq;
using System.Collections.Generic;

namespace Game
{
    class MainClass
    {
        static void Main()
        {
            Console.Clear();
            List<string> logo = new List<string> { "                                  ,'\\", 
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
                "                                `'                            '-._|" };
            foreach (var item in logo)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"welcome to a pathetic ripoff of pokémon!\n\n--------------------------------------------------------");
            
            Playable test = new Playable("Salamalaise", 62, 50, 23, 22);
            Playable isse = new Playable("Pikacringe", 81, 50, 13, 20);
            Playable ahie = new Playable("hé mais il est cheaté lui", 201, 250, 200, 200);
            List<Playable> starterPack = new List<Playable> { test, isse, ahie };

            int pokeCount = 0;
            int potions = 5;
            foreach (var item in starterPack)
            {
                Actions.Stats(item);
                Console.WriteLine($"pick him with {++pokeCount}\n\n--------------------------------------------------------");
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
            Console.Clear();
            Playable player = starterPack[operationN-1];
            Console.WriteLine($"\nyou've chosen {player.name}");
            deck.Add(player);
            while (player.HP > 0)
            {
                if (deck.Count >= 2)
                {
                    Console.WriteLine($"\nMain Menu | [1] - fight a random pokémon\nMain Menu | [2] - check your pokémon's stats\nMain Menu | [3] - heal entirely\nMain Menu | [4] - Pokéswitch \nMain Menu | [x] - leave this trashy game with any other key");
                }
                else Console.WriteLine($"\nMain Menu | [1] - fight a random pokémon\nMain Menu | [2] - check your pokémon's stats\nMain Menu | [3] - heal entirely\nMain Menu | [x] - leave this trashy game with any other key");
                ConsoleKeyInfo operation = Console.ReadKey();
                bool capture = false;
                switch (operation.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        NPC npc = NPC.Generate(player.level);
                        Console.WriteLine($"\n       {player.name}       Vs.       {npc.name}\n{Convert.ToInt32(player.HP)} HP  {player.attack} ATK  {player.defense} DEF     -   {Convert.ToInt32(npc.HP)} HP  {npc.attack} ATK  {npc.defense} DEF");
                        if (npc.speed >= player.speed)
                        {
                            Console.WriteLine($"\nyou're too slow! {npc.name} attacked you first!");
                            Actions.Attack(npc, player);
                        }
                        while (true && player.HP > 0/*  && !capture */)
                        {
                            // if (npc.HP > 11)
                            // {
                            //     Console.WriteLine($"\nIn-game | [1] - attack {npc.name}\nIn-game | [2] - check your stats\nIn-game | [3] - use a potion\nIn-game | [4] - try to get the hell out of here\n");
                            // }
                            // else Console.WriteLine($"\nIn-game | [1] - attack {npc.name}\nIn-game | [2] - check your stats\nIn-game | [3] - use a potion\nIn-game | [4] - try to get the hell out of here\nIn-game | [5] - try to capture {npc.name}\n");
                            Console.WriteLine($"\nIn-game | [1] - attack {npc.name}\nIn-game | [2] - check your stats\nIn-game | [3] - use a potion\nIn-game | [4] - try to get the hell out of here\n {(npc.HP < 11 ? "\nIn-game | [5] - try to capture {npc.name}\n" : "")}");
                            ConsoleKeyInfo inGameOperation = Console.ReadKey();
                            bool fuite = false;
                            switch (inGameOperation.Key)
                            {
                                case ConsoleKey.D1:
                                    Actions.Attack(player, npc); 
                                    if (npc.HP>0) Console.WriteLine($"\n{npc.name}'s health points: {Convert.ToInt32(npc.HP)}/{npc.totalHP}");
                                    break;
                                case ConsoleKey.D2:
                                    Console.Clear();
                                    Actions.Stats(player);
                                    continue;
                                case ConsoleKey.D3:
                                    Console.Clear();
                                    potions = Actions.Heal(player, potions, true);
                                    break;
                                case ConsoleKey.D4:
                                    int fuitest = Random.Shared.Next(100);
                                    if (fuitest > 69)
                                    {
                                        fuite = true;
                                        Console.Clear();
                                        Console.WriteLine($"\nyou successfully managed to escape the battle, coward!");
                                    } else Console.WriteLine($"\nyour escaping attempt failed. :)");
                                    break;
                                case ConsoleKey.D5 when (npc.HP <= 11):
                                    int captProba = Random.Shared.Next(1, 10);
                                    if (captProba >= 5)
                                    {
                                        Console.Clear();
                                        Actions.Capture(captProba, npc, deck);
                                        capture = true;
                                    }
                                    else Console.WriteLine($"you failed to capture {npc.name}!");
                                    break;
                                default:
                                    Console.WriteLine("\nyou're supposed to pick one of the four choices!");
                                    continue;
                            }
                            if (npc.HP <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine($"\ncongrats! you've beaten {npc.name}");
                                player.xp += 14;
                                Playable.xpCheck(player);
                                Actions.addPotion(potions);
                                break;
                            }
                            else if (fuite || capture) break;
                            else Actions.Attack(npc, player);
                            if (player.HP <= 10) Console.WriteLine($"\ncritically low health points! you should use a potion before it's too late for {player.name}.");
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Actions.Stats(player);
                        break;
                    case ConsoleKey.D3:
                        potions = Actions.Heal(player, potions, false);
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        int i = 1;
                        foreach (var item in deck)
                        {
                            Console.WriteLine($"[{i++}] - {item.name} ({Convert.ToInt32(item.HP)}HP, {item.attack}ATK, {item.defense}DEF)");
                        }
                        int pokeChoice = Int32.Parse(Console.ReadKey().KeyChar.ToString());
                        // player = Actions.pokeSwitch(item);
                        player = deck[pokeChoice-1];
                        Console.Clear();
                        Console.WriteLine($"you choose {player.name}");
                        break;
                    default:
                        Console.WriteLine($"\nyou sure you wanna leave? (y/N)");
                        string fChoice = Console.ReadKey().KeyChar.ToString();
                        if (fChoice == "y") return;
                        else continue;
                };
            }
        Console.Clear();
        Console.WriteLine($"GAME OVER :)");
        }
    }
}