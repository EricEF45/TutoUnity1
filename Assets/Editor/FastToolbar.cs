using System.Drawing;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEditor.Toolbars;
using UnityEngine;
using Unity.Utilities;

[Overlay(typeof(SceneView), "MyShorcuts")]
public class FastToolbar : ToolbarOverlay
{
    public FastToolbar() : base(AddCube.Id, AddSphere.Id) {
        this.collapsedIcon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Editor/Icons/shortcuts.png");
    }

    abstract class AddObject : EditorToolbarButton
    {
        PrimitiveType type;

        public AddObject(string tooltip, string icon, PrimitiveType type)
        {
            this.tooltip = tooltip;
            this.icon = AssetDatabase.LoadAssetAtPath<Texture2D>(icon);
            clicked += AddObject_clicked;
            this.type = type;
        }

        private void AddObject_clicked()
        {
            var go = GameObject.CreatePrimitive(type);
            go.FindUniqueName(type.ToString());
            if (!Application.isPlaying)
            {
                Undo.RegisterCreatedObjectUndo(go, $"Create {go.name}");
            }
        }
    }

    [EditorToolbarElement(Id,typeof(SceneView))]
    class AddCube: AddObject
    {
        public const string Id = "MyShorcuts/AddCube";
        public AddCube() : base("Add cube", "Assets/Editor/Icons/cube.png", PrimitiveType.Cube)
        {
        }
    }


    [EditorToolbarElement(Id, typeof(SceneView))]
    class AddSphere : AddObject
    {
        public const string Id = "MyShorcuts/AddSphere";
        public AddSphere() : base("Add sphere", "Assets/Editor/Icons/sphere.png", PrimitiveType.Sphere)
        {
        }
    }
}
