using UnityEngine;

public class CubeScriptAlteredRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 10);
    }
}
