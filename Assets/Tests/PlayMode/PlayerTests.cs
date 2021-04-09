using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTests
    {
        [UnityTest]
        public IEnumerator MoveUp()
        {
            var gameObject = new GameObject();
            var playerController = gameObject.AddComponent<PlayerController>();
            var yPos = playerController.transform.position.y;

            playerController.Move(Vector2.up);

            Assert.IsTrue(playerController.transform.position.y > yPos);
            yield return null;
        }

        [UnityTest]
        public IEnumerator MoveDown()
        {
            var gameObject = new GameObject();
            var playerController = gameObject.AddComponent<PlayerController>();
            var yPos = playerController.transform.position.y;

            playerController.Move(Vector2.down);

            Assert.IsTrue(playerController.transform.position.y < yPos);
            yield return null;
        }

        [UnityTest]
        public IEnumerator MoveLeft()
        {
            var gameObject = new GameObject();
            var playerController = gameObject.AddComponent<PlayerController>();
            var xPos = playerController.transform.position.x;

            playerController.Move(Vector2.left);

            Assert.IsTrue(playerController.transform.position.x < xPos);
            yield return null;
        }

        [UnityTest]
        public IEnumerator MoveRight()
        {
            var gameObject = new GameObject();
            var playerController = gameObject.AddComponent<PlayerController>();
            var xPos = playerController.transform.position.x;

            playerController.Move(Vector2.right);

            Assert.IsTrue(playerController.transform.position.x > xPos);
            yield return null;
        }
    }
}
