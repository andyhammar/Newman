using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Newman.Domain;

namespace Newman.Tests
{
    [TestClass]
    public class GeoServiceTests
    {
        [TestMethod]
        public void should_translate_known_playground_correctly()
        {
            var service = new GeoService();
            var x = "113048,27";
            var y = "6159434,93";
            var position = service.GetPosition(x, y);
            Assert.AreEqual(55.557337, position.Lat, 0.001);
            Assert.AreEqual(12.914515, position.Lng, 0.001);
        }
    }
}
