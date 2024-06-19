using LeafBlowerClawBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafBlowerClawBot.Controllers
{
    public class GameController
    {
        public GameModel game;
        public ConfigModel config = new ConfigModel();
        public GameController()
        {
            config.GetData();
            game = new GameModel(config);
        }

        public void Test()
        {
            Console.WriteLine("Starting tests...");

            for (int i = config.delay; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);

            }

            while(true)
            {
                if (ScreenshotController.TestPlayBtn(config))
                    Console.WriteLine("Can press");
                else
                    Console.WriteLine("Cannot press");
            }
        }

        public void StartGame()
        {
            Console.WriteLine("Program Starting in " + config.delay + " seconds...");

            for (int i = config.delay; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }

            Console.WriteLine();

            Color bgColor = ScreenshotController.GetBackgroundColor(config);
            Console.WriteLine("Background color: " + bgColor.ToString());
            Console.WriteLine();

            // loop for rounds
            while (true)
            {

                if (ScreenshotController.TestPlayBtn(config))
                {
                    KeyboardController.PressSpace();

                    Thread.Sleep(100);

                    // Find the target
                    var (target, score, color, item) = ScreenshotController.FindTarget(config);

                    Console.WriteLine("Item: " + item + "\t\tFound at: " + target + "\tScore: " + score + "\tColor: (" + color.R + "," + color.G + "," + color.B + ")");

                    bool targetFound = false;

                    // while for targetting
                    while (!targetFound)
                    {
                        targetFound = ScreenshotController.CheckForTarget(bgColor, target, config);
                    }

                    // try to grab the target
                    KeyboardController.PressSpace();
                }                    
                //// wait for the round to end
                //Thread.Sleep(game.config.delay * 1000);

                //// initialize the new round
                //KeyboardController.PressSpace();
            }
        }
    }
}
