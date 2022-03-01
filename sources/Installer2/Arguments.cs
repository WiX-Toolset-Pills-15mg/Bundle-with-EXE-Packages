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
using System.Collections.Generic;

namespace DustInTheWind.Installer2
{
    internal class Arguments
    {
        public string InstallDir { get; }

        public ActionType ActionType { get; }

        public string Message { get; }

        public Arguments(IEnumerable<string> args)
        {
            foreach (string item in args)
            {
                string[] parts = item.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 0)
                    continue;

                if (string.Equals(parts[0], "InstallDir", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (parts.Length > 0)
                        InstallDir = parts[1];
                }
                else if (string.Equals(parts[0], "Action", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (parts.Length > 0)
                        ActionType = (ActionType)Enum.Parse(typeof(ActionType), parts[1], true);
                    else
                        ActionType = ActionType.Unknown;
                }
                if (string.Equals(parts[0], "Message", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (parts.Length > 0)
                        Message = parts[1];
                }
            }
        }
    }
}