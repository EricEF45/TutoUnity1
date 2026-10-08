using UnityEngine;

public class ScoreManager
{
    public int GetScore(int mobs, int coins, int hp)
    {
        return mobs * 10 + coins * hp;
    }
    
}
