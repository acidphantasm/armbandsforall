using Comfort.Common;
using EFT;

namespace acidphantasm_letmeout.Utils
{
    public static class MainUtils
    {
        public static Player GetMainPlayer()
        {
            var gameWorld = Singleton<GameWorld>.Instance;
            return gameWorld?.MainPlayer;
        }
    }
}
