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
using DustInTheWind.Installer1.Commands;
using DustInTheWind.Installer2;

namespace DustInTheWind.Installer1
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            try
            {
                Arguments arguments = new(args);
                ApplicationRegistry applicationRegistry = new("BundleWithExePackages-Installer1");

                switch (arguments.ActionType)
                {
                    case ActionType.Unknown:
                        throw new Exception("Unknown action to be executed.");

                    case ActionType.Install:
                        Install(arguments, applicationRegistry);
                        break;

                    case ActionType.Uninstall:
                        Uninstall(arguments, applicationRegistry);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

        private static void Install(Arguments arguments, ApplicationRegistry applicationRegistry)
        {
            InstallCommand installCommand = new(arguments, applicationRegistry);
            installCommand.Execute();

            Console.WriteLine("Install success.");
        }

        private static void Uninstall(Arguments arguments, ApplicationRegistry applicationRegistry)
        {
            UninstallCommand uninstallCommand = new(arguments, applicationRegistry);
            uninstallCommand.Execute();

            Console.WriteLine("Uninstall success.");
        }
    }
}