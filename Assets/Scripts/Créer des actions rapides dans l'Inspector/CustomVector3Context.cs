using UnityEngine;
using UnityEditor;
using System;

public class CustomVector3Context : MonoBehaviour
{
#if UNITY_EDITOR        
    [InitializeOnLoadMethod]
    public static void Init()
    {
        EditorApplication.contextualPropertyMenu += OnPropertyContextMenu;
    }

    private static void OnPropertyContextMenu(GenericMenu menu, SerializedProperty property)
    {
        if (property.propertyType == SerializedPropertyType.Vector3)
        {
            menu.AddItem(new GUIContent("Zero"), false, () => { property.vector3Value = Vector3.zero; SerializeProperty(property); });
            menu.AddItem(new GUIContent("One"), false, () => { property.vector3Value = Vector3.one; SerializeProperty(property); });
            menu.AddItem(new GUIContent("Double"), false, () => { property.vector3Value = property.vector3Value * 2; SerializeProperty(property); });
            menu.AddItem(new GUIContent("Random"), false, () => { float rand = UnityEngine.Random.Range(0.1f,5f); property.vector3Value = new Vector3(rand,rand,rand); SerializeProperty(property); });
        }
    }

    private static void SerializeProperty(SerializedProperty p)
    {
        p.serializedObject.ApplyModifiedProperties();
    }
#endif
}

