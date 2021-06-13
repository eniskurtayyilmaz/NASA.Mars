using System;
using NASA.Mars.Domain;

namespace NASA.Mars.LandManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ask Dimensions
            Console.Write("Please enter dimensions of plateu (Example: 5 5): ");
            string dimensions = Console.ReadLine();
            Plateau plateau = new Plateau(dimensions);

            //Ask how many rovers will add
            Console.Write($"How many number of rovers will add? (Example 2): ");
            string roversStr = Console.ReadLine();
            int roverInt = 0;
            if (!int.TryParse(roversStr, out roverInt))
            {
                Console.WriteLine("Invalid numbers of rovers");
                return;
            }

            
            do
            {
                roverInt--;
                string tagName = $"Rover {(roverInt + 1).ToString()}";

                try
                {
                    //Loading Positions
                    Console.Write($"Please enter drop information for {tagName}(Example: X Y H): ");
                    string information = Console.ReadLine();
                    Position position = new Position(information);

                    //Loading Instructions
                    Console.Write($"Please enter instrucations for {tagName}(Example: LMRMMMLMM): ");
                    string instrucation = Console.ReadLine();
                    Instructions instrucations = new Instructions(instrucation);

                    Rover r = new Rover(tagName, plateau, position, instrucations);

                    r.RunInstructions();
                    Console.WriteLine(r.GetRoverCurrentStatus());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            } while (roverInt > 0);

            Console.ReadKey();
        }
    }
}
