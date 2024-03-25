
using System.Threading.Tasks;

namespace LeafBlowerClawBot.Models
{
    public class GameModel
    {
        public ConfigModel config;
        public GameModel(ConfigModel config)
        {
            this.config = config;
        }
    }
}
