using LeafBlowerClawBot.Controllers;
using LeafBlowerClawBot.Models;
public class Program
{
    public static void Main(string[] args)
    {
        GameController controller = new GameController();

        Console.WriteLine("Starting Leaf Blower Claw Bot");
        controller.StartGame();

        //Console.WriteLine("Starting Leaf Blower Claw Test");
        //controller.Test();
    }
}
