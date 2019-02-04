using OpenQA.Selenium;
using System;

namespace WordpressAutomation
{
    public class PostPage
    {
        public static object Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.ClassName("entry-title"));
                if (title != null)
                    return title.Text;
                return String.Empty;

            }
        }
    }
}
