using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class IncrementValue : MonoBehaviour
{
    public static int count;

    [RuntimeInitializeOnLoadMethod]
    public static void Reset()
    {
        count = 0;
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            print($"{++count}");
        }
    }
}
