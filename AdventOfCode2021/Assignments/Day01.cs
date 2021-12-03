using System;
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
            int increases = 0;
            int lastNumber = 0;

            string[] lines = ReadLines().ToArray();
            lastNumber = Convert.ToInt32(lines[0]);
            lines.GetEnumerator().MoveNext();
            foreach (var line in lines)
            {
                int num = Convert.ToInt32(line);
                if (lastNumber == num) continue;

                if (lastNumber < num)
                    increases++;

                lastNumber = num;
            }
            return $"Increment count: {increases}";
        }

        public override string B()
        {
            int LastNumber = 99999999;

            int increases = 0;

            string[] lines = ReadLines().ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                int num = Convert.ToInt32(lines[i]);
                if (i + 3 > lines.Length) break;
                for (int j = i + 1; j < i + 3; j++)
                {
                    num += Convert.ToInt32(lines[j]);
                }
                if (LastNumber < num)
                    increases++;
                LastNumber = num;
            }

            return $"Increases: {increases}";
        }
    }
}
