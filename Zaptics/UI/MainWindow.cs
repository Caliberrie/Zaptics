using ImGuiNET;
using Serilog;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;
using Zaptics.UI;
using Zaptics.UI.Panels;
using Zaptics.UI.Panels.Subpanels;
using Zaptics.Version;
using Zaptics.Win32;

public class MainWindow 
{
    private Sdl2Window _window;
    private GraphicsDevice _graphicsDevice;
    private const int WindowWidth = 1280;
    private const int WindowHeight = 720;

    private NavbarPanel _navbar;
    private LogPanel _logPanel;
    private QuickControlPanel _quickPanel;

    private IPanel _currentPanel;
    public List<IPanel> Panels = new List<IPanel>()
    {
        new DashboardPanel(),
    };

    public MainWindow()
    {
        _navbar = new NavbarPanel(this);
        _logPanel = new LogPanel();
        _quickPanel = new QuickControlPanel();
    }

    private void HandleNavPanelChange(IPanel newPanel)
    {
        _currentPanel = newPanel;
    }

    public void Open()
    {
        Log.Information("Creating Window and GraphicsDevice");

        var windowOptions = new WindowCreateInfo()
        {
            X = 125,
            Y = 150,
            WindowWidth = WindowWidth,
            WindowHeight = WindowHeight,
            WindowTitle = $"Zaptics ({AppVersion.Current})",
            WindowInitialState = Veldrid.WindowState.Normal,
        };
        VeldridStartup.CreateWindowAndGraphicsDevice(windowOptions, out _window, out _graphicsDevice);

        Log.Information("Creating IMGUI Renderer");
        var framebuffer = _graphicsDevice.MainSwapchain.Framebuffer;
        var imguiRenderer = new ImGuiRenderer(
                _graphicsDevice, 
                framebuffer.OutputDescription,
                (int)framebuffer.Width,
                (int)framebuffer.Height
            );

        ImguiTheme.SetupImGuiStyle();

        var sdlCommandList = _graphicsDevice.ResourceFactory.CreateCommandList();
        
        _window.Resizable = false;

        _currentPanel = Panels[0];

        Log.Information("Entering UI draw loop.");
        while (_window.Exists)
        {
            var input = _window.PumpEvents();
            
            if (!_window.Exists)
                break;

            imguiRenderer.Update(1f / 60f, input);

            sdlCommandList.Begin();
            sdlCommandList.SetFramebuffer(_graphicsDevice.MainSwapchain.Framebuffer);
            sdlCommandList.ClearColorTarget(0, RgbaFloat.Black);

            _navbar.Draw();
            _logPanel.Draw();
            _quickPanel.Draw();
            //_currentPanel.Draw();

            imguiRenderer.Render(_graphicsDevice, sdlCommandList);

            sdlCommandList.End();

            _graphicsDevice.SubmitCommands(sdlCommandList);
            _graphicsDevice.SwapBuffers(_graphicsDevice.MainSwapchain);
        }

        Log.Information("SDL2 Window closed!");
    }
}