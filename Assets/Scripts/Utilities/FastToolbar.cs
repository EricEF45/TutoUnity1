using System.Drawing;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEditor.Toolbars;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Scripts.Utilies
{
    [Overlay(typeof(SceneView), "My Shortcuts")]
    public class FastToolbar : ToolbarOverlay
    {
        public FastToolbar() : base(AddCube.Id, AddSphere.Id)
        {
            this.collapsedIcon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Scripts/Utilities/Resources/shortcuts.png");
        }

        private abstract class AddObject : EditorToolbarButton
        {
            private readonly PrimitiveType _type;

            protected AddObject(string tooltip, string icon, PrimitiveType type)
            {
                this.tooltip = tooltip;
                this.icon = AssetDatabase.LoadAssetAtPath<Texture2D>(icon);
                clicked += AddObject_clicked;
                this._type = type;
            }

            private void AddObject_clicked()
            {
                var go = GameObject.CreatePrimitive(_type);
                go.FindUniqueName(_type.ToString());
                if (!Application.isPlaying)
                {
                    Undo.RegisterCreatedObjectUndo(go, $"Create {go.name}");
                }
            }
        }

        [EditorToolbarElement(Id, typeof(SceneView))]
        class AddCube : AddObject
        {
            public const string Id = "MyShorcuts/AddCube";

            public AddCube() : base("Add cube", "Assets/Scripts/Utilities/Resources/cube.png", PrimitiveType.Cube)
            {
            }
        }


        [EditorToolbarElement(Id, typeof(SceneView))]
        class AddSphere : AddObject
        {
            public const string Id = "MyShorcuts/AddSphere";

            public AddSphere() : base("Add sphere", "Assets/Scripts/Utilities/Resources/sphere.png", PrimitiveType.Sphere)
            {
            }
        }
    }
}