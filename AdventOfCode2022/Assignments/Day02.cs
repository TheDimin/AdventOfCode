using System;
using System.Linq;
using System.Numerics;
using AdventOfCode;

namespace AdventOfCode2021.Assignments
{
    class Day02 : DayAssignment
    {

        struct IVec2
        {
            public int forward;
            public int depth;
        }

        private IVec2 pos;
        private int aim = 0;
        public override int Day { get; } = 2;

        public override void Init()
        {
            //numbers = ParseFileToIntArray();
        }

        public override string A()
        {
            pos = new IVec2();
            foreach (var line in ReadLines())
            {
                string[] commands = line.Split(" ");
                int amount = Convert.ToInt32(commands[1]);
                switch (commands[0])
                {
                    case "forward":
                        pos.forward += amount;
                        break;
                    case "down":
                        pos.depth += amount;
                        break;
                    case "up":
                        pos.depth -= amount;
                        break;
                }
            }
            return $"Code: {pos.depth * pos.forward}";
        }

        public override string B()
        {
            pos = new IVec2();
            foreach (var line in ReadLines())
            {
                string[] commands = line.Split(" ");
                int amount = Convert.ToInt32(commands[1]);
                switch (commands[0])
                {
                    case "forward":
                        pos.forward += amount;
                        pos.depth += aim * amount;
                        break;
                    case "down":
                        aim += amount;
                        break;
                    case "up":
                        aim -= amount;
                        break;
                }
            }
            return  $"Code: {pos.depth * pos.forward}";
        }
    }
}
