using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace UITest
{
    [TestFixture]
    public class Tests
    { 
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp
                .Android
                .ApkFile (@"C:\Users\Rohin Tak\Documents\Visual Studio 2017\Projects\PhoneCallApp\PhoneCallApp\bin\x86\Debug\PhoneCallApp.PhoneCallApp-x86.apk")
                .EnableLocalScreenshots()
                .StartApp();
        }

        [Test]
        public void Toast_Displayed_If_CallButton_Pressed_With_EmptyTextBox()
        {
            app.Screenshot("App Started");
            app.Tap(c => c.Id("CallButton"));
            app.Screenshot("Call Button Pressed");
            AppResult[] result = app.Query(c=> c.Marked("Please provide number"));
            Assert.IsTrue(result.Any(), "Toast not displayed");
        }
    }
}

