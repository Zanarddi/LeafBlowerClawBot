using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafBlowerClawBot.Controllers
{
    public class KeyboardController
    {
        const byte VK_SPACE = 0x20; //The 'Space' key code
        public void PressSpace()
        {
            keybd_event(VK_SPACE, 0, 0, 0);
            keybd_event(VK_SPACE, 0, 0x0002, 0);
            

        }
    }
}
