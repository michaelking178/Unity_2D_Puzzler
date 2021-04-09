using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class ColorTests
    {
        [Test]
        public void Purple()
        {
            var gameObject = new GameObject();
            var colorManager = gameObject.AddComponent<ColorManager>();
            var color = colorManager.CombineColors(colorManager.red, colorManager.blue);
            Assert.AreEqual(colorManager.purple, color);
        }

        [Test]
        public void Orange()
        {
            var gameObject = new GameObject();
            var colorManager = gameObject.AddComponent<ColorManager>();
            var color = colorManager.CombineColors(colorManager.red, colorManager.yellow);
            Assert.AreEqual(colorManager.orange, color);
        }

        [Test]
        public void DarkGreen()
        {
            var gameObject = new GameObject();
            var colorManager = gameObject.AddComponent<ColorManager>();
            var color = colorManager.CombineColors(colorManager.blue, colorManager.yellow);
            Assert.AreEqual(colorManager.darkGreen, color);
        }
    }
}
