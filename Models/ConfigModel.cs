namespace LeafBlowerClawBot.Models
{
    public class ConfigModel
    {
        public int topLeftX { get; set; }
        public int topLeftY { get; set; }
        public int bottomRightX { get; set; }
        public int bottomRightY { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public int maxScore { get; set; }
        public int delay { get; set; }
        public int hookHeight { get; set; }
        public int topLeftXBtn { get; set; }
        public int topLeftYBtn { get; set; }
        public int bottomRightXBtn { get; set; }
        public int bottomRightYBtn { get; set; }
        public List<ColorModel>? itemList { get; set; }
        public Color playBtnOn { get; set; }

        public void GetData()
        {
            this.topLeftX = 260;
            this.topLeftY = 280;
            this.bottomRightX = 1550;
            this.bottomRightY = 750;
            this.topLeftXBtn = 280;
            this.topLeftYBtn = 235;
            this.bottomRightXBtn = 340;
            this.bottomRightYBtn = 275;
            this.height = 470;
            this.width = 1290;
            this.maxScore = 1000;
            this.delay = 5;
            this.hookHeight = 50;
            this.itemList = new List<ColorModel>
            {
                new ColorModel { color = Color.FromArgb(255, 0, 68), name = "Gem" },
                new ColorModel { color = Color.FromArgb(145, 113, 211), name = "Dark Mat." },
                new ColorModel { color = Color.FromArgb(20, 70, 48), name = "Bug" },
                new ColorModel { color = Color.FromArgb(217, 138, 41), name = "Cheese" },
                new ColorModel { color = Color.FromArgb(255, 255, 255), name = "Empty" }
            };
            this.playBtnOn = Color.FromArgb(255, 241, 210);
        }
    }
}
