﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using FestivalSite.Models;

namespace FestivalSite
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "xgNSKlSLd2QkkPR2rr3LOA",
                consumerSecret: "FzLckpXUb9ljFskJznu6kh95wwLNldPxo9oDkMu8rk");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "446732358781900",
                appSecret: "448b2c60a121976eeea15767d7cef351");

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
