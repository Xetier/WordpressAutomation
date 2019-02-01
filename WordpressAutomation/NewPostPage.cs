using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordpressAutomation
{
    public class NewPostPage
    {
        public static object Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.Id("post-title-0"));
                if (title != null)
                    return title.GetAttribute("value");
                return string.Empty;
            }
        }

        public static void GoToNewPost()
        {
            var menuPost = Driver.Instance.FindElement(By.Id("menu-posts"));
            menuPost.Click();

            var addNew = Driver.Instance.FindElement(By.LinkText("Add New"));
            addNew.Click();
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static bool IsInEditMode()
        {
            return Driver.Instance.FindElement(By.XPath("//*[@id='editor']/div/div/div/div[1]/div[2]/button[2]")) != null;
        }
    }

    public class CreatePostCommand
    {
        private string title;
        private string body;

        public CreatePostCommand(string title)
        {
            this.title = title;
        }

        public CreatePostCommand WithBody(string body)
        {
            this.body = body;
            return this;
        }

        public void Publish()
        {
            Driver.Instance.FindElement(By.Id("post-title-0")).SendKeys(title);
            Driver.Instance.FindElement(By.ClassName("editor-block-list__layout")).Click();
            Driver.Instance.FindElement(By.Id("mce_0")).SendKeys(body);

            Thread.Sleep(1000);
            Driver.Instance.FindElement(By.XPath("//*[@id='editor']/div/div/div/div[1]/div[2]/button")).Click();
            Thread.Sleep(1000);
            Driver.Instance.FindElement(By.XPath("//*[@id='editor']/div/div/div/div[1]/div[2]/button")).Click();

            Thread.Sleep(1000);
            Driver.Instance.FindElement(By.XPath("//*[@id='editor']/div/div/div/div[3]/div/div/div[1]/div/button")).Click();

            Thread.Sleep(1000);
            Driver.Instance.FindElement(By.XPath("//*[@id='editor']/div/div/div/div[3]/div/div/div[2]/div/div[2]/div[2]/a")).Click();

        }
    }
}
