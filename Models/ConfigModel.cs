namespace LeafBlowerClawBot.Models
{
    public class ConfigModel
    {
        public int topLeftX { get; set; }
        public int topLeftY { get; set; }
        public int bottomRightX { get; set; }
        public int bottomRightY { get; set; }
        public int delay { get; set; }
        public int hookHeight { get; set; }

        public void GetData()
        {
            this.topLeftX = 260;
            this.topLeftY = 280;
            this.bottomRightX = 1300;
            this.bottomRightY = 500;
            this.delay = 5;
            this.hookHeight = 60;
        }
    }
}
