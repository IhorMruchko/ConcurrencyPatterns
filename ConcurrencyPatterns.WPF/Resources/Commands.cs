using Common.WPF.Commands;
using System;
using System.Windows;

namespace ConcurrencyPatterns.WPF.Resources;

public static class Commands
{
    public static RelayedCommand MinimizeCommand => new(Minimize, CanMinimize);

    public static RelayedCommand MaximizeCommand => new(Maximize, CanMaximize);

    public static RelayedCommand NormalizeCommand => new RelayedCommand(Normalize, CanNormalize);

    public static RelayedCommand CloseCommand => new(Close);

    private static void Close(object? obj)
    {
        if (obj is not Window window)
            return;
        window.Close();
        Environment.Exit(0);
    }

    private static void Maximize(object? obj)
    {
        var window = (Window)obj!;
        window.WindowState = WindowState.Maximized;
    }

    private static bool CanMaximize(object? arg) 
        => arg is Window window && window.WindowState != WindowState.Maximized;


    private static void Normalize(object? obj)
    {
        var window = (Window)obj!;
        window.WindowState = WindowState.Normal;
    }

    private static bool CanNormalize(object? arg) 
        => arg is Window window && window.WindowState != WindowState.Normal;


    private static void Minimize(object? obj)
    {
        var window = (Window)obj!;
        window.WindowState = WindowState.Minimized;
    }

    private static bool CanMinimize(object? arg) 
        => arg is Window window && window.WindowState != WindowState.Minimized;
}
