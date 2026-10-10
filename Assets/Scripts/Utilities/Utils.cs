using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// ReSharper disable once CheckNamespace
namespace Scripts.Utilies
{
    public static class Utils
    {
        public static void DestroyComponentWithUndo<T>(this GameObject go) where T : UnityEngine.Object
        {
            var c = go.GetComponent<T>();
            if (c != null)
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    // 1. USE THE DEDICATED UNDO METHOD INSTEAD OF RecordObject + AddComponent
                    // This handles adding the component AND registers the action to the Undo stack.
                    Undo.DestroyObjectImmediate(c);

                    // 2. Mark dirty as usual
                    EditorUtility.SetDirty(go);
                }
                else
#endif
                {
                    // Runtime fallback (Play Mode or standalone build)
                    UnityEngine.Object.DestroyImmediate(c);
                }
            }
        }

        public static void AddComponentWithUndo<T>(this GameObject go) where T : UnityEngine.Component
        {
            var c = go.GetComponent<T>();
            if (c == null)
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    // 1. USE THE DEDICATED UNDO METHOD INSTEAD OF RecordObject + AddComponent
                    // This handles adding the component AND registers the action to the Undo stack.
                    Undo.AddComponent<T>(go);

                    // 2. Mark dirty as usual
                    EditorUtility.SetDirty(go);
                }
                else
#endif
                {
                    // Runtime fallback (Play Mode or standalone build)
                    c = go.AddComponent<T>();
                }
            }
        }

        private static bool _isprocessing = false;
        public static void ExecuteMenuOnce(Action a)
        {
#if UNITY_EDITOR
            if (_isprocessing) return;
            _isprocessing = true;
            // Schedule the flag reset to happen after Unity finishes executing all menu iterations
            EditorApplication.delayCall += () => { _isprocessing = false; };
#endif
            a();
        }

        public static string FindUniqueName(this GameObject go, string name)
        {
            var n = name;
            int counter = 1;
            var g = GameObject.Find(n);
            while (g != null)
            {
                if (g == go) return n;
                n = $"{name} ({counter++})";
                g = GameObject.Find(n);
            }
            if (go != null) go.name = n;
            return n;
        }
    }
}
