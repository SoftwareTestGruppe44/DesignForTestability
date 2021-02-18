using NUnit.Framework;
namespace ECSLegacy.Test.Unit
{
    public class WindowTestClass
    {
        private IWindow _window;
        private FakeConsole _console;
        [SetUp]
        public void Setup()
        {
            _console = new FakeConsole();
            _window = new Window(_console);
        }

        [Test]
        public void Open_OpenWindow_WindowIsOpened()
        {
            //Arrange
            //Act
            _window.Open();
            //Assert
            Assert.AreEqual(_console.ConsoleLine, "Window is open");
        }

        [Test]
        public void Close_CloseWindow_WindowIsClosed()
        {
            //Arrange
            //Act
            _window.Close();
            //Assert
            Assert.AreEqual(_console.ConsoleLine, "Window is closed");
        }
    }
}