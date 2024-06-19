namespace LeafBlowerClawBot.Controllers
{
    public class KeyboardController
    {
        public static void PressSpace()
        {
            SendKeys.SendWait(" ");
        }
    }
}
