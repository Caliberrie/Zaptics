using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Zaptics.UI.Panels
{
    public class QuickControlPanel : IDrawable
    {
        public void Draw()
        {
            ImGui.SetNextWindowPos(new Vector2(0, 720-250));
            ImGui.SetNextWindowSize(new Vector2(250, 250));

            var windowFlags = ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoTitleBar;

            ImGui.Begin("QuickControls", windowFlags);

            ImGui.Text("          Quick Panel");

            var allDisable = false;
            ImGui.Checkbox("All Disable", ref allDisable);
            ImGui.Checkbox("Shock Enabled", ref allDisable);

            ImGui.End();
        }
    }
}
