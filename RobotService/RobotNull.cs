using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService
{
    class RobotNull : Robot
    {
        protected override bool Compile()
        {
            File.WriteAllText(folder + "compiler.out", "Error: This Programing Language does not supported");
            return false;
        }

        protected override void RunTest(string inFile, string outFile)
        {
            return;
        }
    }
}
