//================================================================================
// Class   : ProcessTest
// Version : 2.00
//
// Created : 20/04/2019 - 1.00 - Carlos Oliveira - Class creation
// Updated : 13/09/2019 - 2.00 - Gelder Carvalho - Class refactoring
//================================================================================

using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using OpenQA.Selenium;

namespace Starline
{
    public class ProcessTest : AutoReport
    {
        //Compatibility with older codes
        public string PathDoProjeto { get; set; }
        public string PastaBase { get; set; }
        
        public ProcessTest()
        {
            
        }

        public string PrintPageComSelenium(IWebDriver driver, bool full = false, int sleep = 0)
        {
            try
            {
                if (sleep > 0)
                {
                    System.Threading.Thread.Sleep(sleep * 1000);
                }

                //Create base directory and set image filename
                string printPath = GetAppPath() + "/Prints" + "/" + CustomerName + "/" + RptID.ToString() + "/" + SuiteName + "/" + ScenarioName + "/" + TestName;
                if (!Directory.Exists(printPath))
                {
                    Directory.CreateDirectory(printPath);
                }
                string filename = printPath + "/" + StepNumber.ToString().PadLeft(4, '0') + "_" + StepTurn.ToString().PadLeft(2, '0') + "-" + TestName.Replace("-", "_") + ".png";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                if (full)
                {
                    /*
                        Dispositivo			Width	X	Heigh
                        Reponsive			400		X	1397
                        Galaxy S5			360		X	640
                        Pixel 2				411		X	731
                        Pixel 2 XL			411		X	823
                        iPhone 5/SE			320		X	568
                        iPhone 6/7/8		375		X	667
                        iPhone 6/7/8 Plus	414		X	736
                        iPhone X			375		X	812
                        iPad				768		X	1024
                        iPad Pro			1024	X	1366
                    */

                    Bitmap stitchedImage = null;

                    // First scroll to load all page components
                    ((IJavaScriptExecutor)driver).ExecuteScript(String.Format("window.scrollBy({0}, {1})", 0, -100000));
                    for (int p = 0; p < 200; p++)
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript(String.Format("window.scrollBy({0}, {1})", 0, 500));
                        System.Threading.Thread.Sleep(5);
                    }
                    ((IJavaScriptExecutor)driver).ExecuteScript(String.Format("window.scrollBy({0}, {1})", 0, -100000));
                    System.Threading.Thread.Sleep(200);

                    // Get full page size
                    long totalwidth1 = (long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.offsetWidth");//documentElement.scrollWidth");
                    long totalHeight1 = (long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.parentNode.scrollHeight");
                    int totalWidth = (int)totalwidth1;
                    int totalHeight = (int)totalHeight1;

                    // Get viewport size
                    long viewportWidth1 = (long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.clientWidth");//documentElement.scrollWidth");
                    long viewportHeight1 = (long)((IJavaScriptExecutor)driver).ExecuteScript("return window.innerHeight");//documentElement.scrollWidth");
                    int viewportWidth = (int)viewportWidth1;
                    int viewportHeight = (int)viewportHeight1;

                    // Split screen in multiple rectangles
                    List<Rectangle> rectangles = new List<Rectangle>();

                    // Loop until total height
                    for (int i = 0; i < totalHeight; i += viewportHeight)
                    {
                        int newHeight = viewportHeight;
                        
                        // Fix if element height too big
                        if (i + viewportHeight > totalHeight)
                        {
                            newHeight = totalHeight - i;
                        }
                        
                        // Loop until total width
                        for (int ii = 0; ii < totalWidth; ii += viewportWidth)
                        {
                            int newWidth = viewportWidth;
                            
                            // Fix if element width too big
                            if (ii + viewportWidth > totalWidth)
                            {
                                newWidth = totalWidth - ii;
                            }

                            // Create and add new rectangle
                            Rectangle currRect = new Rectangle(ii, i, newWidth, newHeight);
                            rectangles.Add(currRect);
                        }
                    }

                    // Build image
                    stitchedImage = new Bitmap(totalWidth, totalHeight);

                    // Get all screenshots together
                    Rectangle previous = Rectangle.Empty;
                    foreach (var rectangle in rectangles)
                    {
                        // Calculate needed scrolling
                        if (previous != Rectangle.Empty)
                        {
                            int xDiff = rectangle.Right - previous.Right;
                            int yDiff = rectangle.Bottom - previous.Bottom;
                            ((IJavaScriptExecutor)driver).ExecuteScript(String.Format("window.scrollBy({0}, {1})", xDiff, yDiff));
                            System.Threading.Thread.Sleep(200);
                        }

                        // Take screenshot
                        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                        // Build an image from the screenshot
                        Image screenshotImage;
                        using (MemoryStream memStream = new MemoryStream(screenshot.AsByteArray))
                        {
                            screenshotImage = Image.FromStream(memStream);
                        }

                        // Calculate source rectangle
                        Rectangle sourceRectangle = new Rectangle(viewportWidth - rectangle.Width, viewportHeight - rectangle.Height, rectangle.Width, rectangle.Height);

                        // Copy image
                        using (Graphics g = Graphics.FromImage(stitchedImage))
                        {
                            g.DrawImage(screenshotImage, rectangle, sourceRectangle, GraphicsUnit.Pixel);
                        }

                        // Set previous rectangle
                        previous = rectangle;
                    }

                    // Save image file
                    stitchedImage.Save(filename, ImageFormat.Png);
                }
                else
                {
                    Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                    ss.SaveAsFile(filename, ScreenshotImageFormat.Png);
                }
                return filename;
            }
            catch (Exception ex)
            {
                Print("Exception at PrintPageComSelenium", ex);
                return null;
            }
        }
    }
}
