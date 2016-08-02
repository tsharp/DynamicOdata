﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Http.Dispatcher;
using DynamicOdata.Service.Owin;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DynamicOdata.SelfHost.StartupOwin))]

namespace DynamicOdata.SelfHost
{
  public class StartupOwin
  {
    public void Configuration(IAppBuilder app)
    {
      var oDataServiceSettings = new ODataServiceSettings();
      oDataServiceSettings.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
      oDataServiceSettings.RoutePrefix = "odata";
      oDataServiceSettings.Schema = "dbo";

      HttpConfiguration config = new HttpConfiguration();

      config.EnableSystemDiagnosticsTracing();

      app.UseDynamicOData(config, oDataServiceSettings);
      app.UseWebApi(config);
    }
  }
}