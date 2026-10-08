using NUnit.Framework;

public class NewTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void NPCTestSimplePass()
    {
        var npc = new NPC("test");
        Assert.AreEqual("test", npc.thename);
        Assert.AreEqual(1, npc.level);
        npc.LevelUp();
        Assert.AreEqual(2, npc.level);
        Assert.AreEqual(true, npc.isAlly);
        npc.ChangeTeam();
        Assert.AreEqual(false, npc.isAlly);
    }
}
