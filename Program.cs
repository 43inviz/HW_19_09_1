using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace HW_19_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string childProcPath = "notepad.exe";
            Process childProcess = new Process();
            childProcess.StartInfo.FileName = childProcPath;
            childProcess.StartInfo.UseShellExecute = false;
            childProcess.StartInfo.RedirectStandardOutput = true;
            childProcess.StartInfo.RedirectStandardError = true;
            childProcess.StartInfo.CreateNoWindow = true;
            childProcess.EnableRaisingEvents = true;
            childProcess.Exited += (sender, eventArg) =>
            {
                int exitCode = childProcess.ExitCode;
                Console.WriteLine($"Процесс завершился с кодом {exitCode}");
                childProcess.Dispose();
            };
            childProcess.Start();
            childProcess.WaitForExit();

        }
    }
}
