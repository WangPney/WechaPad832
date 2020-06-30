using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechat.Util.ProcessInfos
{
    public class ProcessHelper
    {
        public static (int, string) Excute(string exe, string args)
        {
            var startInfo = new ProcessStartInfo()
            {
                FileName = exe,
                Arguments = args,
                RedirectStandardError = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var p = new Process())
            {
                p.StartInfo = startInfo;
                p.Start();

                var output = p.StandardOutput.ReadToEnd();

                p.WaitForExit();

                return (p.ExitCode, output);
            }
        }
    }
}
