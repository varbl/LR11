using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;

public class UniqueUsersFilter : IActionFilter
{
    private readonly HashSet<string> uniqueUsers = new HashSet<string>();
    private readonly string logFilePath = "unique_users_log.txt"; 
     
    public void OnActionExecuting(ActionExecutingContext context)
    {

        string userIdentifier = context.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";

        lock (uniqueUsers)
        {
            uniqueUsers.Add(userIdentifier);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        lock (uniqueUsers)
        {
            File.WriteAllText(logFilePath, $"Unique users count: {uniqueUsers.Count}");
        }
    }
}
