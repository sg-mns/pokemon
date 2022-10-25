class MainClass
{
    static void Main()
    {
        Pokemon test = new Pokemon("Salamalaise", 51, 50, 12, 20);
        Pokemon isse = new Pokemon("Pikacringe", 100, 50, 12, 20);
        Pokemon ahie = new Pokemon("hé mais il est cheaté lui", 201, 250, 200, 200);
        List<Pokemon> starterPack = new List<Pokemon> { test, isse, ahie };
        List<Pokemon> pokemons = new List<Pokemon> { test, isse };

        Actions.Stats(pokemons[0]);
        Console.WriteLine($"what to do next?");

        // Console.WriteLine($"t'as le choix entre :\n{starterPack[0].name} [health(1)\n{starterPack[1]} (2)\n{starterPack[2]} (3)");            
        int ptDR = 0;
        foreach (var item in starterPack)
        {
            Actions.Stats(item);
            Console.WriteLine($"attrapez-le avec {++ptDR}\n--------------------------------------------------------");
            
        }
        Console.WriteLine(pokemons[0].name);
        List<Pokemon> deck = new List<Pokemon> {  };
        // Console.WriteLine(operation switch
        // {            
        //     "1" => Actions.Attack(pokemons[0], pokemons[1]),
        //     "2" => Actions.Stats(pokemons[0]),
        //     _ => "Error"
        // });

        while (true)
        {
            string operation = Console.ReadLine();
            switch (operation)
            {
                case "1":
                    Console.WriteLine(Actions.Attack(pokemons[0], starterPack[2]));
                    break;
                case "2":
                    Actions.Stats(pokemons[0]);
                    break;
                default:
                    return;
            };
        }
    }
}