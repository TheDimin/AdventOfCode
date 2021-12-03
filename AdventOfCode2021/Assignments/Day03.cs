using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AdventOfCode;

namespace AdventOfCode2021.Assignments
{
    class Day03 : DayAssignment
    {
        public override int Day { get; } = 3;


        private List<uint> indexCount = new List<uint>();
        private int amountCount = 0;
        private uint finalNumber = 0;

        public override void Init()
        {
            indexCount.Clear();
            amountCount = 0;
            finalNumber = 0;
        }


        public override string A()
        {
            foreach (var line in ReadLines())
            {
                int i = 0;
                foreach (var bit in line)
                {
                    uint bitv = Convert.ToUInt32($"{bit}");
                    if (indexCount.Count <= i)
                        indexCount.Add(bitv);
                    else
                        indexCount[i] += bitv;
                    i++;
                }

                amountCount++;
            }

            int codeIndex = indexCount.Count - 1;
            foreach (var indexSum in indexCount)
            {
                if (indexSum >= amountCount / 2)
                    finalNumber += ((uint)1) << codeIndex;


                codeIndex--;
            }

            //0b111111111111
            return $"Code: {finalNumber * ((~finalNumber) & 0b111111111111)}";
        }

        public override string B()
        {
            string[] answers = new string[] { "", "" };

            for (int i = 0; i < 2; i++)
            {
                List<string> strings = ReadLines().ToList();
                //GetValueForBit
                for (int j = 0; j < strings[0].Length; j++)
                {
                    int finalBitValue = 0;
                    char bit = ' ';

                    foreach (var schar in strings)
                        if (schar[j] == '1')
                            finalBitValue++;

                    if (i == 0)
                    {
                        if (finalBitValue * 2 == strings.Count)
                            bit = '1';
                        else
                            bit = (char)((finalBitValue > strings.Count / 2 ? '1' : '0'));
                    }
                    else
                    {
                        if (finalBitValue * 2 == strings.Count)
                            bit = '0';
                        else
                            bit = (char)((finalBitValue * 2 < strings.Count ? '1' : '0'));
                    }


                    //Remove elements of list
                    for (int k = strings.Count - 1; k >= 0; k--)
                    {
                        if (strings[k][j] != bit)
                            strings.RemoveAt(k);
                    }

                    if (strings.Count == 1)
                        break;
                }

                answers[i] = strings[0];

            }


            return $"Code: {Convert.ToInt32(answers[0],2) * Convert.ToInt32(answers[1],2)}";
        }
    }
}
