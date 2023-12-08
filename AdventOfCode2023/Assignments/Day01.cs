using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode;

namespace AdventOfCode2021.Assignments
{
    class Day01 : DayAssignment
    {

        public override int Day { get; } = 1;

        public override void Init()
        {
            //numbers = ParseFileToIntArray();
        }

        public override string A()
        {
            int sum = 0;

            foreach (var line in ReadLines())
            {
                char firsti = ' ';
                char lasti = ' ';
                bool first = true;
                foreach (var lineChar in line)
                {

                    int i = 0;
                    if (int.TryParse($"{lineChar}", out i))
                    {
                        if (first)
                        {
                            firsti = lineChar;
                            lasti = lineChar;
                            first = false;
                        }
                        else
                        {
                            lasti = lineChar;
                        }
                    }
                }

                int ii = 0;
                int.TryParse($"{firsti}{lasti}", out ii);
                sum += ii;
            }

            return $"sum: {sum}";
        }

        private string[] names = new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        public override string B()
        {
            int sum = 0;

            foreach (var line in ReadLines())
            {
                char firsti = ' ';
                char lasti = ' ';
                bool first = true;
                for (int i = 0; i < line.Length; i++)
                {
                    int value = 0;
                    if (int.TryParse($"{line[i]}", out value))
                    {
                        if (first)
                        {
                            firsti = line[i];
                            lasti = line[i];
                            first = false;
                        }
                        else
                        {
                            lasti = line[i];
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (line.Substring(i).StartsWith(names[j]))
                            {
                                if (first)
                                {
                                    firsti = $"{j + 1}"[0];
                                    lasti = firsti;
                                    first = false;
                                }
                                else
                                {
                                    lasti = $"{j + 1}"[0];
                                }

                               // i += names[j].Length - 1;

                                break;
                            }
                        }
                    }
                }
                Console.WriteLine($"{firsti}{lasti}");
                int ii = 0;
                int.TryParse($"{firsti}{lasti}", out ii);
                sum += ii;
            }

            return $"sum: {sum}";
        }
    }
}
