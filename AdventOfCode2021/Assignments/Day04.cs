using System;
using System.Linq;
using AdventOfCode;

namespace AdventOfCode2021.Assignments
{
    class Day04 : DayAssignment
    {
        private string[] bingoNumbers = new string[0];
        private string[][] bingoMaps = new string[0][];

        private const int boardSize = 5;

        public override int Day { get; } = 4;
        public override void Init()
        {
            string[] lines = ReadLines().ToArray();
            //hack the first line

            string[] inputs = lines[0].Split(',');
            bingoNumbers = new string[inputs.Length];
            for (int i = 0; i < inputs.Length; i++)
            {
                bingoNumbers[i] = inputs[i];
            }

            int boards = (lines.Length - 1) / (boardSize + 1);

            bingoMaps = new string[boards][];

            int boardElmCount = boardSize * boardSize;

            int mapID = 0;
            //Parse every board
            for (int fileLine = 2; fileLine < lines.Length; fileLine += boardSize + 1)
            {
                bingoMaps[mapID] = new string[boardElmCount];

                for (int h = 0; h < boardSize; h++)
                {
                    string[] mapLine = lines[fileLine + h].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (int w = 0; w < boardSize; w++)
                    {
                        bingoMaps[mapID][h * boardSize + w] = mapLine[w];
                    }
                }

                mapID++;
            }
        }

        int CalculateWinnerSum(string[] mapLevel)
        {
            int sum = 0;
            foreach (var s in mapLevel)
            {
                if (s == "")
                    continue;

                sum += Convert.ToInt32(s);
            }

            return sum;
        }

        private int AMapID = 0;
        public override string A()
        {
            foreach (var BingoNumber in bingoNumbers)
            {

                foreach (var map in bingoMaps)
                {
                    for (int j = 0; j < map.Length; j++)
                    {
                        if (map[j] == BingoNumber)
                            map[j] = "";
                    }

                    //Check if map wins
                    bool[] winsy = new bool[boardSize];
                    for (int i = 0; i < boardSize; i++)
                        winsy[i] = true;

                    for (int h = 0; h < boardSize; h++)
                    {
                        bool winsx = true;

                        for (int w = 0; w < boardSize; w++)
                        {
                            //CheckX
                            if (map[h * boardSize + w] != "")
                            {
                                winsx = false;
                                winsy[w] = false;
                            }
                        }

                        if (winsx)
                            return $"{CalculateWinnerSum(map) * Convert.ToInt32(BingoNumber)}";
                    }

                    for (int i = 0; i < boardSize; i++)
                    {
                        if (winsy[i])
                            return $"{CalculateWinnerSum(map) * Convert.ToInt32(BingoNumber)}";
                    }

                    AMapID++;
                }
            }
            return $"No code found";
        }


        private int mapsLeft = 0;

        void SwapMap(int map)
        {

            for (int i = map + 1; i < mapsLeft; i++)
            {
                bingoMaps[i - 1] = bingoMaps[i];
            }

            mapsLeft--;
        }

        public override string B()
        {
            mapsLeft = bingoMaps.Length - 1;

            foreach (var BingoNumber in bingoNumbers)
            {
                AMapID = 0;
                for (int m = mapsLeft; m >= 0; m--)
                {
                    for (int j = 0; j < bingoMaps[m].Length; j++)
                    {
                        if (bingoMaps[m][j] == BingoNumber)
                            bingoMaps[m][j] = "";
                    }

                    //Check if map wins
                    bool[] winsy = new bool[boardSize];
                    bool winsx = true;
                    for (int i = 0; i < boardSize; i++)
                        winsy[i] = true;

                    for (int h = 0; h < boardSize; h++)
                    {
                        winsx = true;

                        for (int w = 0; w < boardSize; w++)
                        {
                            //CheckX
                            if (bingoMaps[m][h * boardSize + w] != "")
                            {
                                winsx = false;
                                winsy[w] = false;
                            }
                        }

                        if (winsx)
                        {
                            if (mapsLeft == 1)
                                return $"{(CalculateWinnerSum(bingoMaps[0]) + Convert.ToInt32(BingoNumber)) * Convert.ToInt32(BingoNumber)}";


                            SwapMap(AMapID);
                        }
                    }

                    if (!winsx)
                        for (int i = 0; i < boardSize; i++)
                            if (winsy[i])
                            {
                                if (mapsLeft == 1)
                                    return $"{(CalculateWinnerSum(bingoMaps[0])) * Convert.ToInt32(BingoNumber)}";

                                SwapMap(AMapID);
                            }

                    AMapID++;
                }


            }
            return $"Code: ";
        }
    }
}
