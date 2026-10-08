using NUnit.Framework;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine.SceneManagement;

public class ScoreManagerTests
{
    [Test]
    [TestCase(1, 1, 1, 11)]
    [TestCase(2, 3, 4, 32)]
    [TestCase(2, 0, 0, 20)]
    [TestCase(0, 3, 4, 12)]
    public void GetScore_Test(int mobs, int coins, int hp, int result)
    {
        var scoreManager = new ScoreManager();
        int score = scoreManager.GetScore(mobs: mobs, coins: coins, hp: hp);
        Assert.AreEqual(result, score);
    }
}
