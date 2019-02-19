namespace RobotService
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading;

    internal sealed class Program
    {
        private const string BasePath = @"C:\#Robot\data";
        private const string WaitDirectoryName = @"wait";
        private const string WorkDirectoryName = @"work";
        private const string DoneDirectoryName = @"done";
        private const int ProcessDelay = 5000;

        private static void Main()
        {
            Process();
        }



        private static void Process()
        {
            while (true)
            {
                Ping();
                Work();
                Delay();
            }
        }

        private static void Work()
        {
            var folders = GetFolders();

            foreach (var folder in folders)
            {
                Console.WriteLine();
                Console.WriteLine($"Working on {folder}");

                MoveFolder(folder, WaitDirectoryName, WorkDirectoryName);

                var robot = Robot.CreateRobot(Path.Combine(BasePath, WorkDirectoryName, folder));

                robot.Start();

                MoveFolder(folder, WorkDirectoryName, DoneDirectoryName);
            }
        }

        private static void Ping()
        {
            Console.Write(".");
        }

        private static void Delay()
        {
            Thread.Sleep(ProcessDelay);
        }

        private static IEnumerable<string> GetFolders()
        {
            return Directory.GetDirectories(Path.Combine(BasePath, WaitDirectoryName))
                .Select(Path.GetFileName);
        }

        private static void MoveFolder(string folder, string from, string to)
        {
            Directory.Move(Path.Combine(BasePath, from, folder), Path.Combine(BasePath, to, folder));
        }
    }
}
