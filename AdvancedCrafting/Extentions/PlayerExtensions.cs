using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace AdvancedCrafting.Extentions
{
    public static class PlayerExtensions
    {
        public static Player Player(this IRocketPlayer rocketPlayer)
            => ((UnturnedPlayer)rocketPlayer).Player;
    }
}
