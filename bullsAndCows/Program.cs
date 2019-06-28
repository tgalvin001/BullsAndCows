using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace bullsAndCows
{
    class Program
    {

        public static char[] toBeGuessed()
        {
            List<char> number = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            char[] arr = new char[4];
            Random random = new Random();

            for(int i = 0; i < 4; i++)
            {
                int index = random.Next(number.Count);
                arr[i] = number[index];
                number.RemoveAt(index);
            }
            return arr;
        }
        static void Main(string[] args)
        {
            bool playTheGame = true;
            while(playTheGame)
            {

                var guess = new char[4];
                bool inGame = true;
                char[] arr1 = toBeGuessed();

                while(inGame)
                {
                    int bull = 0;
                    int cow = 0;
                    Console.WriteLine("Guess 4 digit number: ");
                    guess = Console.ReadLine().ToCharArray();
                    while (guess.Length != 4)
                    {
                        Console.WriteLine("Your guess needs to be 4 digits");
                        guess = Console.ReadLine().ToCharArray();

                    }
            
                    for(int i = 0; i < 4; i++)
                    {
                        if(arr1.Contains(guess[i]))
                        {
                            if(arr1[i].Equals(guess[i]))
                                bull++;
                            else    
                                cow++;
                        }
                    }
                    Console.WriteLine("Bulls: {0} Cows: {1}",bull, cow);
                    if(bull == 4)
                    {    
                        inGame = false;
                        Console.Write("Correct!!! The number was ");
                        foreach(char c in arr1)
                        {
                            Console.Write($"{c}");
                        }
                    }

                }
                Console.WriteLine(" Do you want to keep playing? (y/n)?");
                string playAgain = null;
                playAgain = Console.ReadLine();
                if(playAgain == "n")
                    playTheGame = false;
                else
                    Console.WriteLine("Lets try again!!!");
            }
            Console.WriteLine("Thanks for playing. Goodbye");
            Console.ReadKey();
        }
    }
}
