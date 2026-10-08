using UnityEngine;

public class ChangeInspectorMenu : MonoBehaviour
{
    [ContextMenu("SetBlue")]
    public void SetBlue()
    {
        GetComponent<Renderer>().sharedMaterial.color = Color.blue;
    }

    [ContextMenu("SetRed")]
    public void SetRed()
    {
        GetComponent<Renderer>().sharedMaterial.color = Color.red;
    }
}
