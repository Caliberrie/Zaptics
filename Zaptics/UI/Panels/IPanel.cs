using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaptics.UI.Panels
{
    public abstract class IPanel : IDrawable
    {
        public bool IsActive;
        public abstract string GetName();
        public abstract void OnOpen();
        public abstract void OnClose();
        public abstract void Draw();
    }
}
