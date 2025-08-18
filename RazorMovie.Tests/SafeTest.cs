using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using RazorMovie.SharedServices;

namespace RazorMovie.Tests
{
    [TestClass]
    public sealed class SafeTest
    {
        [TestMethod]
        public void Safe_CanRawEncode()
        {
            // TODO: Fix CS0246: The type or namespace name 'HtmlSanitizer' could not be found. You may need to add a reference to the appropriate package or project, or use a different sanitizer implementation compatible with net9.0.
            var mockJsonHelper = new Mock<IJsonHelper>();
            var moqHtmlHelper = new Mock<IHtmlHelper>();
            moqHtmlHelper.Setup(m => m.Raw(It.IsAny<string>())).Returns((string s) => new HtmlString(s));

            var converter = new Safe(moqHtmlHelper.Object, mockJsonHelper.Object, htmlSanitizer);

            var actualText = "Hello<script>alert('Hello')</script>World";

            var result = converter.Raw(actualText);

            Assert.AreEqual("HelloWorld", result.ToString());
        }
    }
}
