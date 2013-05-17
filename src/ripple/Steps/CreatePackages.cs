﻿using System.Collections.Generic;
using System.Linq;
using FubuCore;
using FubuCore.CommandLine;
using NuGet;
using ripple.Commands;

namespace ripple.Steps
{
    public class CreatePackages : RippleStep<LocalNugetInput>
    {
        protected override void execute(LocalNugetInput input, IRippleStepRunner runner)
        {
            new FileSystem().CreateDirectory(input.DestinationFlag);

            Solution.Specifications.Each(spec => {
                var version = spec.Dependencies.Any(x => x.VersionSpec != null && x.VersionSpec.ToString().Contains("-"))
                                  ? input.VersionFlag + "-alpha"
                                  : input.VersionFlag;


                RippleLog.Info("Building the nuget spec file at " + spec.Filename + " as version " + version);

                Solution.Package(spec, SemanticVersion.Parse(version), input.DestinationFlag);
                ConsoleWriter.PrintHorizontalLine();
            });
        }
    }
}