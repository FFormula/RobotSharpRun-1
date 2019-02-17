using System.IO;

namespace RobotService
{
    class RobotSharp : Robot
    {
        protected override bool Compile()
        {
            RunCommand(@"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /nologo Program.cs > compiler.out");
            return new FileInfo(folder + "compiler.out").Length == 0;
        }

        protected override void RunTest(string inFile, string outFile)
        {
            RunCommand(@"Program.exe < " + inFile + " > " + outFile + " 2>&1");
        }
    }
}
