//using UnityEditor;
//using UnityEngine;

//[InitializeOnLoad]
//public class DropScriptInHierarchy
//{
//    static DropScriptInHierarchy()
//    {
//        DragAndDrop.AddDropHandlerV2(onDropHandler);
//    }

//    private static DragAndDropVisualMode onDropHandler(EntityId dropTargetEntityId, HierarchyDropFlags dropMode, Transform parentForDraggedObjects, bool perform)
//    {
//        var scripts = GetScripts();
//        if ((scripts?.Length ?? 0) > 0)
//        {
//            if (perform)
//            {
//                var list = new System.Collections.Generic.List<GameObject>();
//                foreach (var s in scripts)
//                {
//                    var go = CreateObject(s.name);
//                    list.Add(go);
//                    go.AddComponent(s.GetClass());
//                }
//                Selection.objects = list.ToArray();
//            }
//            return DragAndDropVisualMode.Copy;
//        }
//        return DragAndDropVisualMode.None;
//    }

//    private static MonoScript[] GetScripts()
//    {
//        var list = new System.Collections.Generic.List<MonoScript>();
//        foreach (var o in DragAndDrop.objectReferences)
//        {
//            if (o is MonoScript ms)
//            {
//                list.Add(ms);
//            }
//        }
//        return list.ToArray();
//    }

//    private static GameObject CreateObject(string name)
//    {
//        var go = new GameObject(name);
//        if (!Application.isPlaying)
//        {
//            Undo.RegisterCreatedObjectUndo(go, $"Create {name}");
//        }
//        return go;
//    }
//}
