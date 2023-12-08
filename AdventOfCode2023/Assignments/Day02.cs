using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode;

namespace AdventOfCode2023.Assignments
{
    class Day02 : DayAssignment
    {

        public override int Day { get; } = 2;

        struct Round
        {
            public int red = 0;
            public int green = 0;
            public int blue = 0;

            public Round()
            {
            }
        }

        struct Game
        {
            public int id;
            public List<Round> rounds = new List<Round>();

            public Game()
            {
                id = 0;
            }
        }


        List<Game> games = new List<Game>();
        public override void Init()
        {
            games = new List<Game>();
            foreach (var line in ReadLines())
            {
                Game game = new Game();
                string[] split = line.Split(":");
                game.id = Int32.Parse($"{split[0].Split(' ')[1]}");


                string[] gamesSplit = split[1].Split(';');
                foreach (var gameString in gamesSplit)
                {
                    Round round = new Round();

                    //num COLOur
                    foreach (var gameInfo in gameString.Split(','))
                    {
                        string[] infoPair = gameInfo.Split(' ');
                        int amount = Int32.Parse(infoPair[1]);

                        if (infoPair[2] == "red")
                        {
                            round.red = amount;
                        }
                        else if (infoPair[2] == "green")
                        {
                            round.green = amount;
                        }
                        else if (infoPair[2] == "blue")
                        {
                            round.blue = amount;
                        }
                    }


                    game.rounds.Add(round);
                }

                games.Add(game);
            }
        }

        public override string A()
        {
            List<int> validGames = new List<int>();

            foreach (var game in games)
            {
                bool used = true;
                foreach (var round in game.rounds)
                {
                    if (round.red > 12)
                    {
                        used = false;
                        break;
                    }
                    else if (round.green > 13)
                    {
                        used = false;
                        break;

                    }
                    else if (round.blue > 14)
                    {
                        used = false;
                        break;
                    }

                }
                if (used)
                    validGames.Add(game.id);
            }


            return $"{validGames.Sum()}";
        }

        public override string B()
        {
            List<int> gameSums = new List<int>();

            foreach (var game in games)
            {
                int r = 0, g = 0, b = 0;

                foreach (var round in game.rounds)
                {
                    if (round.red > r)
                    {
                        r = round.red;
                    }

                    if (round.green > g)
                    {
                        g = round.green;
                    }

                    if (round.blue > b)
                    {
                        b = round.blue;
                    }
                }
                gameSums.Add(r * g * b);
            }


            return $"{gameSums.Sum()}";
        }
    }
}
