using System.Runtime.InteropServices;
using Serilog;

namespace Zaptics.WinApiInterop
{
    public static class Win32ConsoleUtil
    {
        [DllImport("Kernel32.dll")]
        private static extern nint GetConsoleWindow();

        [DllImport("User32.dll")]
        private static extern bool ShowWindow(nint hWnd, int cmdShow);

        public static void SetVisible(bool visible)
        {
            var windowPointer = GetConsoleWindow();
            if (windowPointer != nint.Zero)
            {
                ShowWindow(windowPointer, visible ? 1 : 0);
            }
            else
            {
                Log.Error("GetConsoleWindow returned null pointer.");
            }
        }

        public static void Hide() => SetVisible(false);

        public static void Show() => SetVisible(true);
    }
}
