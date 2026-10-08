using UnityEngine;

public class NPC : MonoBehaviour
{
    public string thename;
    public int level;
    public bool isAlly;

    public NPC(string n)
    {
        thename = n;
        level = 1;
        isAlly = true;
    }
    public void LevelUp()
    {
        level++;
    }
    public void ChangeTeam()
    {
        isAlly = !isAlly;
    }
}
