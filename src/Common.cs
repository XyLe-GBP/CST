using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace chusongtool
{
    internal class Common
    {
        internal class Generic
        {
            public static string CurrentDir = Directory.GetCurrentDirectory();
            public static string TempDir = Directory.GetCurrentDirectory() + @"\temp";
            public static string ResourcesDir = Directory.GetCurrentDirectory() + @"\res";
            public static string CRI_ADX2Dir = TempDir + @"\adx2\";
            public static string StreamDir = "", StreamDirName = "";
            public static FileVersionInfo Version = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
        }

        internal class Utils
        {
            /// <summary>
            /// Process.Start: Open URI for .NET
            /// </summary>
            /// <param name="URI">http://~ または https://~ から始まるウェブサイトのURL</param>
            public static void OpenURI(string URI)
            {
                try
                {
                    Process.Start(URI);
                }
                catch
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        //Windowsのとき  
                        URI = URI.Replace("&", "^&");
                        Process.Start(new ProcessStartInfo("cmd", $"/c start {URI}") { CreateNoWindow = true });
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        //Linuxのとき  
                        Process.Start("xdg-open", URI);
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        //Macのとき  
                        Process.Start("open", URI);
                    }
                    else
                    {
                        throw;
                    }
                }

                return;
            }

            /// <summary>
            /// 現在の時刻を取得する
            /// </summary>
            /// <returns>YYYY-MM-DD-HH-MM-SS (例：2000-01-01-00-00-00)</returns>
            public static string SFDRandomNumber()
            {
                DateTime dt = DateTime.Now;
                return dt.Year + "-" + dt.Month + "-" + dt.Day + "-" + dt.Hour + "-" + dt.Minute + "-" + dt.Second;
            }

            /// <summary>
            /// 指定したディレクトリ内のファイルも含めてディレクトリを削除する
            /// </summary>
            /// <param name="targetDirectoryPath">削除するディレクトリのパス</param>
            public static void DeleteDirectory(string targetDirectoryPath)
            {
                if (!Directory.Exists(targetDirectoryPath))
                {
                    return;
                }

                string[] filePaths = Directory.GetFiles(targetDirectoryPath);
                foreach (string filePath in filePaths)
                {
                    File.SetAttributes(filePath, FileAttributes.Normal);
                    File.Delete(filePath);
                }

                string[] directoryPaths = Directory.GetDirectories(targetDirectoryPath);
                foreach (string directoryPath in directoryPaths)
                {
                    DeleteDirectory(directoryPath);
                }

                Directory.Delete(targetDirectoryPath, false);
            }

            /// <summary>
            /// 指定したディレクトリ内のファイルのみを削除する
            /// </summary>
            /// <param name="targetDirectoryPath">削除するディレクトリのパス</param>
            public static void DeleteDirectoryFiles(string targetDirectoryPath)
            {
                if (!Directory.Exists(targetDirectoryPath))
                {
                    return;
                }

                DirectoryInfo di = new(targetDirectoryPath);
                FileInfo[] fi = di.GetFiles();
                foreach (var file in fi)
                {
                    file.Delete();
                }
                return;
            }

            /// <summary>
            /// 完了後に保存先のフォルダを開く
            /// </summary>
            /// <param name="Fullpath">フォルダのフルパス</param>
            /// <param name="Flag">フラグ</param>
            public static void ShowFolder(string Fullpath, bool Flag = true)
            {
                if (Flag != false)
                {
                    Process.Start("EXPLORER.EXE", @"/select,""" + Fullpath + @"""");
                    return;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
