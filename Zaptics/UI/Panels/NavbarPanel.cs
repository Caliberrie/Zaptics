using ImGuiNET;
using System.Numerics;
using Zaptics.UI.Panels.Subpanels;

namespace Zaptics.UI.Panels
{
    internal class NavbarPanel : IDrawable
    {
        private readonly MainWindow mainWindow;

        public int CurrentPanelIndex { get; private set; }

        public event Action<IPanel> OnPanelChanged;

        public NavbarPanel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void Draw()
        {
            ImGui.SetNextWindowPos(new Vector2(0, 0));
            ImGui.SetNextWindowSize(new Vector2(250, 720-250));

            var windowFlags = ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoTitleBar;
            ImGui.Begin("Navbar", windowFlags);

            ImGui.Text(" ");
            var font = ImGui.GetFont();
            font.Scale = 2;
            ImGui.PushFont(font);
            ImGui.Text("     Zaptics");
            font.Scale = 1;
            ImGui.PopFont();
            ImGui.Text(" ");

            for (var i = 0; i < mainWindow.Panels.Count; i++)
            {
                var panel = mainWindow.Panels[i];

                if (ImGui.Button(panel.GetName(), new Vector2(235, 40)))
                {
                    OnPanelChanged?.Invoke(panel);
                }
            }

            ImGui.End();
        }
    }
}
