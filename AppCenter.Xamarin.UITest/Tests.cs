using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace AppCenter.Xamarin.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void MenuButtonBehavior()
        {
            app.Screenshot("Init");
            app.Tap("MenuButton1");
            app.WaitForElement(c => c.Marked("message"));
            app.Screenshot("Tap MenuButton1");
            var message = app.Query(c => c.Marked("message")).FirstOrDefault();
            Assert.IsNotNull(message);
            Assert.AreEqual("購買が押されました。", message.Text);
            app.Tap("button2");
            app.WaitForNoElement(c => c.Marked("message"));
            app.Screenshot("Dialog was closed.");
        }

        [Test]
        [Ignore("For repl")]
        public void StartRepl()
        {
            app.Repl();
        }
    }
}
