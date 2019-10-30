using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dorokhov
{
    public static class AppData
    {
        public static Frame MainFrame = new Frame();
        public static Entities.DorokhovEntities Context = new Entities.DorokhovEntities();
    }
}
