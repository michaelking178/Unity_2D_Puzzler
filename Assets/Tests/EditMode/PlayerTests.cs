using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTests
    {
        [Test]
        public void Freeze()
        {
            var gameObject = new GameObject();
            var player = gameObject.AddComponent<PlayerController>();
            player.Freeze();
            Assert.IsFalse(player.canControlMovement);
        }

        [Test]
        public void Unfreeze()
        {
            var gameObject = new GameObject();
            var player = gameObject.AddComponent<PlayerController>();
            player.Unfreeze();
            Assert.IsTrue(player.canControlMovement);
        }
    }
}
