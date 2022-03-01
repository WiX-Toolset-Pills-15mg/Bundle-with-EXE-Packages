using System;
using Microsoft.Win32;

namespace DustInTheWind.Installer2
{
    internal class ApplicationRegistry
    {
        private readonly string applicationKeyName;
        private const string manufacturerKeyName = "DustInTheWind";

        public ApplicationRegistry(string applicationKeyName)
        {
            this.applicationKeyName = applicationKeyName ?? throw new ArgumentNullException(nameof(applicationKeyName));
        }

        public string GetInstallDir()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("Software");

            key = key.OpenSubKey(manufacturerKeyName);
            key = key.OpenSubKey(applicationKeyName);

            return key.GetValue("InstallDir").ToString();
        }

        public void SetInstallDir(string installDir)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true);

            key.CreateSubKey(manufacturerKeyName);
            key = key.OpenSubKey(manufacturerKeyName, true);

            key.CreateSubKey(applicationKeyName);
            key = key.OpenSubKey(applicationKeyName, true);

            key.SetValue("InstallDir", installDir);
        }

        public void SetMessage(string message)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true);

            key.CreateSubKey(manufacturerKeyName);
            key = key.OpenSubKey(manufacturerKeyName, true);

            key.CreateSubKey(applicationKeyName);
            key = key.OpenSubKey(applicationKeyName, true);

            key.SetValue("Message", message);
        }

        public void RemoveAll()
        {
            RegistryKey softwareKey = Registry.LocalMachine.OpenSubKey("Software", true);
            RegistryKey dustInTheWindKey = softwareKey?.OpenSubKey(manufacturerKeyName, true);

            if (dustInTheWindKey == null)
                return;

            dustInTheWindKey.DeleteSubKeyTree(applicationKeyName);

            if (dustInTheWindKey.SubKeyCount == 0)
                softwareKey.DeleteSubKey(manufacturerKeyName);
        }
    }
}