using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using RazorMovie.SharedServices;
using Ganss.Xss;

namespace RazorMovie.Tests
{
    [TestClass]
    public sealed class SafeTest
    {
        [TestMethod]
        public void Safe_CanRawEncode()
        {
            var mockJsonHelper = new Mock<IJsonHelper>();
            var moqHtmlHelper = new Mock<IHtmlHelper>();
            moqHtmlHelper.Setup(m => m.Raw(It.IsAny<string>())).Returns((string s) => new HtmlString(s));

            var htmlSanitizer = new HtmlSanitizer();
            var converter = new Safe(moqHtmlHelper.Object, mockJsonHelper.Object, htmlSanitizer);

            var actualText = "Hello<script>alert('Hello')</script>World";

            var result = converter.Raw(actualText);

            Assert.AreEqual("HelloWorld", result.ToString());
        }
    }
}
