﻿namespace AdvancedCrafting.Other.Webhook
{
    public class Webhook
    {
        public bool Enabled { get; set; }

        public string Url { get; set; }

        public string SuccessColor { get; set; }

        public string FailColor { get; set; }

        public Webhook()
        {

        }

        public Webhook(bool enabled, string webhookurl, string fail, string success)
        {
            Enabled = enabled;
            Url = webhookurl;
            SuccessColor = success;
            FailColor = fail;
        }
    }
}
