using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
using System.Web.Mvc;

namespace LR11

{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            string logMessage = $"Action '{actionName}' in controller '{controllerName}' called at {DateTime.Now}";

            WriteToLogFile(logMessage);
        }

        private void WriteToLogFile(string message)
        {
            string filePath = @"C:\Logs\actionLog.txt"; 

            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(message);
            }
        }
    }
}
