using System;
using System.Diagnostics;
using System.Text;

namespace ShadowSocketChangePort.Common
{
    public static class Utils
    {
        private static string ConfigPath = string.Empty;

        public static string GetConfigPath()
        {
            if (ConfigPath != string.Empty)
            {
                return ConfigPath;
            }
            string tempPath = System.IO.Path.GetTempPath();
            string configPath = System.IO.Path.Combine(tempPath, "shadowsocks/config.json");
            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(configPath));
            }
            catch
            {
            }
            return configPath;
        }

        public static string RunCommand(string fileName, string arguments)
        {
            try
            {
                //创建一个ProcessStartInfo对象 使用系统shell 指定命令和参数 设置标准输出
                var psi = new ProcessStartInfo()
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{fileName} {arguments}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };
                //启动
                var proc = Process.Start(psi);
                string resultStr = string.Empty;
                resultStr = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();
                return resultStr;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
