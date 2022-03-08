// WiX Toolset Pills 15mg
// Copyright (C) 2019-2022 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.IO;

namespace DustInTheWind.Installer1.Commands
{
    internal class InstallCommand
    {
        private readonly Arguments arguments;
        private readonly ApplicationRegistry applicationRegistry;

        public InstallCommand(Arguments arguments, ApplicationRegistry applicationRegistry)
        {
            this.arguments = arguments ?? throw new ArgumentNullException(nameof(arguments));
            this.applicationRegistry = applicationRegistry ?? throw new ArgumentNullException(nameof(applicationRegistry));
        }

        public void Execute()
        {
            CreateInstallDirectory();
            DeployFiles();
            WriteRegistryInfo();
        }

        private void CreateInstallDirectory()
        {
            if (string.IsNullOrWhiteSpace(arguments.InstallDir))
                throw new Exception("Please provide the install dir.");

            Directory.CreateDirectory(arguments.InstallDir);
        }

        private void DeployFiles()
        {
            for (int i = 0; i < 10; i++)
            {
                string filePath = Path.Combine(arguments.InstallDir, $"file-{i:D2}");
                File.WriteAllText(filePath, $"This is the file {i:D2}.");
            }
        }

        private void WriteRegistryInfo()
        {
            applicationRegistry.SetInstallDir(arguments.InstallDir);

            if (!string.IsNullOrEmpty(arguments.Message))
                applicationRegistry.SetMessage(arguments.Message);
        }
    }
}