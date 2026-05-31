using NUnit.Framework;
using SuperMario.Core;
using UnityEngine;
using UnityEngine.TestTools;

namespace SuperMario.Tests.EditMode
{
    public class GameManagerTests
    {
        private GameObject gameManagerObject;

        [SetUp]
        public void SetUp()
        {
            gameManagerObject = new GameObject("GameManager");
            gameManagerObject.AddComponent<GameManager>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(gameManagerObject);
        }

        [Test]
        public void AddCoin_At100ResetsCoinsAndAddsLife()
        {
            var manager = GameManager.Instance;

            for (int i = 0; i < 99; i++) {
                manager.AddCoin();
            }

            Assert.AreEqual(99, manager.coins);

            manager.AddCoin();

            Assert.AreEqual(0, manager.coins);
            Assert.AreEqual(4, manager.lives);
        }

        [Test]
        public void ResetLevel_DecrementsLives()
        {
            var manager = GameManager.Instance;

            LogAssert.ignoreFailingMessages = true;
            manager.ResetLevel();
            LogAssert.ignoreFailingMessages = false;

            Assert.AreEqual(2, manager.lives);
        }
    }
}
