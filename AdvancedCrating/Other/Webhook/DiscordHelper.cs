using Newtonsoft.Json.Linq;
using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCrating.Other.Webhook
{
    public class DiscordHelper
    {
        public static void FailCraftWebhook(UnturnedPlayer player, string Url, string FailColor, ushort rewardItem)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                wc.UploadString(
                    Url,
                    new JObject
                    {
                        ["embeds"] = new JArray
                        {
                            JToken.FromObject(new
                            {
                                color = Convert.ToInt32(FailColor, 16),
                                description = "** " + player.DisplayName + " ** has failed to craft: `" + rewardItem + "` \n Player Steam Account: https://steamcommunity.com/profiles/" + player.CSteamID
                            })
                        }
                    }.ToString());
            }
        }
        public static void SuccessCraftWebhook(UnturnedPlayer player, string Url, string SuccessColor, ushort rewardItem)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                wc.UploadString(
                    Url,
                    new JObject
                    {
                        ["embeds"] = new JArray
                        {
                            JToken.FromObject(new
                            {
                                color = Convert.ToInt32(SuccessColor, 16),
                                description = "** " + player.DisplayName + " ** has succedded to craft: `" + rewardItem + "` \n Player Steam Account: https://steamcommunity.com/profiles/" + player.CSteamID
                            })
                        }
                    }.ToString());
            }
        }
    }
}