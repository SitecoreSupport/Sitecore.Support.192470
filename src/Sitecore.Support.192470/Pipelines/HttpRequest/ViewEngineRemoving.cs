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
    public class ViewEngineRemoving : HttpRequestProcessor
    {
        private static bool flag = false;
        public override void Process(HttpRequestArgs args)
        {
            if (!flag)
            {
                var itemToRemove = ViewEngines.Engines.Where(i => i.GetType().Equals(typeof(PrecompiledMvcEngine))).ToList();

                for (int i = 0; i < itemToRemove.Count; i++)
                {
                    ViewEngines.Engines.Remove(itemToRemove[i]);
                }
                flag = true;
            }
        }
    }
}