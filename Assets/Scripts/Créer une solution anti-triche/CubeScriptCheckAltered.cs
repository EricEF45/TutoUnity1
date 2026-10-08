using System;
using UnityEngine;

public class CubeScriptCheckAltered : MonoBehaviour
{
    static CubeScriptCheckAltered Instance;
    public int timeDiff = 0;
    int prevTime = 0;
    int realTime = 0;
    float gameTime = 0;
    public bool cheatDetected = false;

    private void Awake()
    {
        if( Instance== null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        prevTime = DateTime.Now.Second;
        gameTime = 1;
    }

    private void FixedUpdate()
    {
        if (prevTime != DateTime.Now.Second)
        {
            realTime++;
            prevTime = DateTime.Now.Second;
            timeDiff = (int)gameTime - realTime;
            if (timeDiff > 4)
            {
                if (!cheatDetected)
                {
                    cheatDetected = true;
                    HackDetected();
                }
            }
            else
            {
                cheatDetected = false;
            }
        }
        gameTime += Time.deltaTime;
    }

    void HackDetected()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
