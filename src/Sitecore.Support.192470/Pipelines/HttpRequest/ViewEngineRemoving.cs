using RazorGenerator.Mvc;
using Sitecore.Pipelines;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Support.Pipelines.HttpRequest
{
    public class ViewEngineRemoving: HttpRequestProcessor
    {
        private static bool flag = false;
        public override void Process(HttpRequestArgs args)
        {
            if (!flag)
            {
                for (int i = 0; i < ViewEngines.Engines.Count; i++)
                {
                    var precompiledViewEngine = ViewEngines.Engines[0] as PrecompiledMvcEngine;
                    if (precompiledViewEngine != null)
                    {
                        ViewEngines.Engines.Remove(precompiledViewEngine);
                        flag = true;
                    }
                }
            }
        }
    }
}