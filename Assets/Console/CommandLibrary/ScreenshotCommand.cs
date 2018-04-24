using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Console
{
    [AutoRegisterConsoleCommand]
    public class ScreenshotCommand : IConsoleCommand
    {
        public void Execute(string[] args)
        {
            int size = 1;
            if(args.Length == 1)
            {
                int.TryParse(args[0], System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out size);
                size = Math.Min(size, 5);
                size = Math.Max(size, 1);
            }
            DateTime now = DateTime.Now;
            string datetime = string.Format("{0}{1}{2}-{3}{4}{5}",now.Year, now.Month, now.Day, now.Hour,now.Minute,now.Second);
            string filename = string.Format("Unity-{0}-{1}-{2}.png", Application.productName, SceneManager.GetActiveScene().name, datetime);
            Console.Log(GetName(), string.Format("Taking Screenshot at {0}x resolution : {1}",size, filename));
            ScreenCapture.CaptureScreenshot(filename,1);
        }

        public string GetHelp()
        {
            return @"usage: screenshot [supersize 1~5]";
        }

        public string GetName()
        {
            return "screenshot";
        }

        public IEnumerable<Console.Alias> GetAliases()
        {
            return null;
        }

        public string GetSummary()
        {
            return "Takes a screenshot";
        }
    }

}
