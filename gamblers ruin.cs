using System;

namespace ConsoleApp1
{
    using System;

    namespace ConsoleApp2
    {
        class Program
        {


            public class GamblersRuin
            {
                private static bool Tosscoin()
                {
                    //let heads = 1 and tails = 0
                    // if it generates 1 then it returns true otherwise it returns false
                    
                    return new Random().Next(2) == 1;
                }
                public static bool Rungame(int n1, int n2)
                {
                    // when both the players have coins the game will keep going
                    while (n1 != 0 & n2 != 0)
                    {
                        //the coin is tossed, if its heads then tosscoin() returns true, if its tails tosscoin() returns false
                        // the player either chooses heads or tails so choice will be true for for 1 which is heads 
                        // and choice will be false for 0 which is tails
                        bool choice = new Random().Next(2) ==1;
                        if (Tosscoin() == choice)
                        {
                            n1 = n1 + 1;
                            n2 = n2 - 1;

                        }
                        else
                        {
                            n1 = n1 - 1;
                            n2 = n2 + 1;

                        }
                    }
                    //when player two has no coins player 1 wins 
                    if (n2 == 0)
                    {
                        return true;
                    }
                    // otherwise player 2 wins
                    else
                    {
                        return false;
                    }
                }
            }
            class test
            {
                static void Main(string[] args)
                {
                    //both players start at zero wins
                    int a = 0;
                    int b = 0;
                    //when they have played the game a hundred times the loop stops
                    while (a + b != 100)
                    {
                        // if rubgame is true then player 1 wins
                        if (GamblersRuin.Rungame(100, 100))
                        {
                            a = a + 1;

                        }
                        // if rungame is false then player two wins
                        else
                        {
                            b = b + 1;
                        }
                    }
                    Console.WriteLine("in the first game player1 wins {0} times and player2 wins {1} times", a, b);

                    int c = 0;
                    int d = 0;
                    while (c + d != 100)
                    {
                        if (GamblersRuin.Rungame(150, 50))
                        {
                            c = c + 1;

                        }
                        else
                        {
                            d = d + 1;
                        }
                    }
                    Console.WriteLine("in the second game player1 wins {0} times and player2 wins {1} times", c, d);
                }
            }

        }
    }

}