using LeafBlowerClawBot.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafBlowerClawBot.Controllers
{
    public class ScreenshotController
    {

        public static (byte[], Bitmap, Graphics) TakeScreenshot(int x1, int y1, int x2, int y2)
        {
            int width = x2 - x1;
            int height = y2 - y1;
            var bmpScreenshot = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(x1,
                                         y1,
                                         0,
                                         0,
                                         new Size(width, height),
                                         CopyPixelOperation.SourceCopy);

            //bmpScreenshot.Save("Screenshot.png", ImageFormat.Png);

            byte[] byteArray;
            using (var stream = new MemoryStream())
            {
                bmpScreenshot.Save(stream, ImageFormat.Png);
                stream.Position = 0;
                byteArray = stream.ToArray();
            }
            return (byteArray, bmpScreenshot, gfxScreenshot);
        }

        public static Color GetBackgroundColor(ConfigModel config)
        {
            var (screenShot, bmpScreenshot, gfxScreenshot) = TakeScreenshot(config.topLeftX, config.topLeftY, config.bottomRightX, config.topLeftY + config.hookHeight);
            var backCol = bmpScreenshot.GetPixel(0, 0);
            gfxScreenshot.Dispose();
            bmpScreenshot.Dispose();
            return backCol;
        }

        public static bool CheckForTarget(Color bgColor, int target, ConfigModel config)
        {
            var (screenShot, bmpScreenshot, gfxScreenshot) = TakeScreenshot(config.topLeftX, config.topLeftY, config.bottomRightX, config.topLeftY + config.hookHeight);
            if(bmpScreenshot.GetPixel(target, config.hookHeight/2) != bgColor)
                return true;
            return false;
        }

        public static (int, int, Color, string) FindTarget(ConfigModel config)
        {
            int maxScore = 765;
            int bestScoreX = 0;
            Color bestColor = Color.FromArgb(0, 0, 0);
            string bestItem = "Empty";

            // Take screenshot
            var (screenShot, bmpScreenshot, gfxScreenshot) = TakeScreenshot(config.topLeftX, config.topLeftY, config.bottomRightX, config.bottomRightY);

            // Find the target
            foreach(ColorModel item in config.itemList)
            {
                var (bestScoreXItem, bestScoreItem, bestColorItem) = testForColor(item.color, config, bmpScreenshot);
                if(bestScoreItem == 0)
                {
                    maxScore = bestScoreItem;
                    bestScoreX = bestScoreXItem;
                    bestColor = bestColorItem;
                    bestItem = item.name;
                    break;
                }
            }

            gfxScreenshot.Dispose();
            bmpScreenshot.Dispose();
            return (bestScoreX, maxScore, bestColor, bestItem);
        }

        public static (int, int, Color) testForColor(Color color, ConfigModel config, Bitmap bmpScreenshot)
        {

            int width = config.width;
            int height = config.height;
            int bestScore = config.maxScore;
            int bestScoreX = config.maxScore;
            Color bestColor = Color.FromArgb(0, 0, 0);

            // starts at 100 and ends at 95% of the width to avoid being out of bounds of the hook
            for (int x = 100; x < width * 0.95; x += 3)
            {
                for (int y = 0; y < height; y += 3)
                {
                    Color testCol = bmpScreenshot.GetPixel(x, y);
                    int score = GetScore(testCol, color);
                    if (score < bestScore)
                    {
                        bestColor = testCol;
                        bestScore = score;
                        bestScoreX = x;
                    }
                }
            }

            return (bestScoreX, bestScore, bestColor);
        }

        public static int GetScore(Color testCol, Color targetCol)
        {
            int score = Math.Abs(testCol.R - targetCol.R) + Math.Abs(testCol.G - targetCol.G) + Math.Abs(testCol.B - targetCol.B);
            return score;
        }

        public static bool TestPlayBtn(ConfigModel config)
        {
            var (screenShot, bmpScreenshot, gfxScreenshot) = TakeScreenshot(config.topLeftXBtn, config.topLeftYBtn, config.bottomRightXBtn, config.bottomRightYBtn);

            bool found = false;

            loop();

            gfxScreenshot.Dispose();
            bmpScreenshot.Dispose();

            return found;

            void loop()
            {
                for (int x = 0; x < (config.bottomRightXBtn - config.topLeftXBtn); x += 3)
                {
                    for (int y = 0; y < (config.bottomRightYBtn - config.topLeftYBtn); y += 3)
                    {
                        Color testCol = bmpScreenshot.GetPixel(x, y);
                        int score = GetScore(testCol, config.playBtnOn);
                        if (score == 0)
                        {
                            found = true;
                            return;
                        }
                    }
                }
            }
        }
    }
}
