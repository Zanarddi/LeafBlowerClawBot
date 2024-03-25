using LeafBlowerClawBot.Controllers;
using LeafBlowerClawBot.Models;
public class Program
{
    public static void Main(string[] args)
    {
        GameController controller = new GameController();
        controller.StartGame();
    }
}
