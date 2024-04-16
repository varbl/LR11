using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.Filters;

public class LogActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {

        LogToFile($"Executing {context.ActionDescriptor.DisplayName} at {DateTime.Now}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {

        LogToFile($"Executed {context.ActionDescriptor.DisplayName} at {DateTime.Now}");
    }

    private void LogToFile(string message)
    {

        string logFilePath = "action_log.txt";

        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine(message);
        }
    }
}