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
        public GameController()
        {
            ConfigModel config = new ConfigModel();
            config.GetData();
            game = new GameModel(config);
        }

        public void StartGame()
        {


            Thread.Sleep(game.config.delay * 1000);


            while(true){
                // Take screenshot
                int target = ScreenshotController.FindTarget();
                if(target == -1)
                {
                    // No target found
                    Thread.Sleep(200); // Wait for 200ms
                    // Check the target horizontal position
                    // Start the claw moving with the right horizontal position
                }
                else
                {
                    // Target found
                    // Move the claw to the right
                    // Check the target horizontal position
                    // Start the claw moving with the right horizontal position
                }
                // Check the target horizontal position
                // Start the claw moving with the right horizontal position

            }


            Console.WriteLine("Game Started");
        }
    }
}
