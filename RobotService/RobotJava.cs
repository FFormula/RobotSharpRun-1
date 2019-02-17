using System.IO;

namespace RobotService
{
    class RobotJava : Robot
    {

        protected override bool Compile()
        {
            RunCommand(@"""C:\Program Files\Java\jdk1.8.0_201\bin\javac.exe"" Program.java 2> compiler.out");
            return new FileInfo(folder + "compiler.out").Length == 0;
        }

        protected override void RunTest(string inFile, string outFile)
        {
            RunCommand(@"""C:\Program Files\Java\jdk1.8.0_201\bin\java.exe"" Program < " + inFile + " > " + outFile + " 2>&1");
        }
    }
}
