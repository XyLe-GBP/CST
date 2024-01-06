namespace chusongtool
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            string mutexName = "ChuSongTool";
            Mutex mutex = new(false, mutexName);

            bool hasHandle = false;
            try
            {
                try
                {
                    hasHandle = mutex.WaitOne(0, false);
                }
                catch (AbandonedMutexException)
                {
                    hasHandle = true;
                }
                if (hasHandle == false)
                {
                    MessageBox.Show("Multiple launch of applications is not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Directory.Exists(Directory.GetCurrentDirectory() + @"\res\sat"))
                {
                    if (!File.Exists(Directory.GetCurrentDirectory() + @"\res\sat\acbeditor.exe"))
                    {
                        MessageBox.Show("The required file 'acbeditor.exe' does not exist.\nClose the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("The SonicAudioTools directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Directory.Exists(Directory.GetCurrentDirectory() + @"\res\dt\release"))
                {
                    if (!File.Exists(Directory.GetCurrentDirectory() + @"\res\dt\release\hca2wav.exe"))
                    {
                        MessageBox.Show("The required file 'hca2wav.exe' does not exist.\nClose the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!File.Exists(Directory.GetCurrentDirectory() + @"\res\dt\release\hcaenc.exe"))
                    {
                        MessageBox.Show("The required file 'hcaenc.exe' does not exist.\nClose the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!File.Exists(Directory.GetCurrentDirectory() + @"\res\dt\release\hcacc.exe"))
                    {
                        MessageBox.Show("The required file 'hcacc.exe' does not exist.\nClose the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("The DereTools directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                

                ApplicationConfiguration.Initialize();
                Application.Run(new FormMain());
            }
            finally
            {
                if (hasHandle)
                {
                    mutex.ReleaseMutex();
                }
                mutex.Close();
            }
        }
    }
}