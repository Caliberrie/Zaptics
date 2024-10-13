using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Zaptics.Logging;

namespace Zaptics.UI.Panels.Subpanels
{
    internal class LogPanel : IDrawable
    {
        private LogType _currentType = LogType.All;

        public void Draw()
        {
            ImGui.SetNextWindowPos(new Vector2(250, 720-250));
            ImGui.SetNextWindowSize(new Vector2(1280-250, 250));

            var buttonSize = new Vector2(100, 25);
            var windowFlags = ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoTitleBar;

            ImGui.Begin("LogPanel", windowFlags);

            ImGui.Text("Log Filter:");

            var logTypes = Enum.GetValues<LogType>();
            for (var i = 0; i < logTypes.Length; i++)
            {
                var isActivated = _currentType.HasFlag(logTypes[i]);
                
                //ImGui.Button(logTypes[i].ToString(), buttonSize);
                if (i != logTypes.Length - 1)
                    ImGui.SameLine();
            }

            ImGui.Separator();

            ImGui.End();
        }
    }
}
