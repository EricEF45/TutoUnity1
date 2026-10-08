using UnityEngine;

public class SetSizeFromVector : MonoBehaviour
{
    public Vector3 size;

    void Start()
    {
        transform.localScale = size;    
    }
}
