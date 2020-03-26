﻿// Licensed to the .NET Foundation under one or more agreements.0
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Mono.Options;
using System;
using System.Collections.Generic;

namespace XHarness.iOS
{
    public class iOSGetStateCommand : Command
    {
        bool ShowHelp = false;

        public iOSGetStateCommand() : base("state")
        {
            Options = new OptionSet() {
                "usage: ios state",
                "",
                "Print information about the current machine, such as host machine info and device status",
                { "help|h", "Show this message", v => ShowHelp = v != null }
            };
        }

        public override int Invoke(IEnumerable<string> arguments)
        {
            // Deal with unknown options and print nicely 
            var extra = Options.Parse(arguments);
            if (ShowHelp)
            {
                Options.WriteOptionDescriptions(Console.Out);
                return 1;
            }
            if (extra.Count > 0)
            {
                Console.WriteLine($"Unknown arguments: {string.Join(" ", extra)}");
                Options.WriteOptionDescriptions(Console.Out);
            }
            Console.WriteLine("iOS state command called (no args supported)");
            return 0;
        }
    }
}
