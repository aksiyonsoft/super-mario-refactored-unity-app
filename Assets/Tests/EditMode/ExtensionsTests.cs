using NUnit.Framework;
using SuperMario.Utilities;
using UnityEngine;

namespace SuperMario.Tests.EditMode
{
    public class ExtensionsTests
    {
        [Test]
        public void DotTest_ReturnsTrueWhenStompingFromAbove()
        {
            var player = new GameObject("Player").transform;
            var enemy = new GameObject("Enemy").transform;

            player.position = new Vector3(0f, 2f, 0f);
            enemy.position = Vector3.zero;

            Assert.IsTrue(player.DotTest(enemy, Vector2.down));

            Object.DestroyImmediate(player.gameObject);
            Object.DestroyImmediate(enemy.gameObject);
        }

        [Test]
        public void DotTest_ReturnsFalseWhenHitFromSide()
        {
            var player = new GameObject("Player").transform;
            var enemy = new GameObject("Enemy").transform;

            player.position = Vector3.zero;
            enemy.position = new Vector3(2f, 0f, 0f);

            Assert.IsFalse(player.DotTest(enemy, Vector2.down));

            Object.DestroyImmediate(player.gameObject);
            Object.DestroyImmediate(enemy.gameObject);
        }
    }
}
