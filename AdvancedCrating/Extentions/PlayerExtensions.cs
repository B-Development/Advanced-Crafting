using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace AdvancedCrating.Extentions
{
    public static class PlayerExtensions
    {
        public static Player Player(this IRocketPlayer rocketPlayer)
        {
            return ((UnturnedPlayer)rocketPlayer).Player;
        }
    }
}
