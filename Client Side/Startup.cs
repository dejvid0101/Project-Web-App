﻿using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

[assembly: OwinStartup(typeof(Client_Side.App_Start.Startup))]

namespace Client_Side.App_Start
{
    public partial class Startup
    {
        

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}