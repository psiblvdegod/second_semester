// <copyright file="Program.cs" author="psiblvdegod">
// under MIT License
// </copyright>

#pragma warning disable SA1200

using Avalonia;

AppBuilder.Configure<GUI.App>()
    .UsePlatformDetect()
    .StartWithClassicDesktopLifetime(args);
