using UnityEditor;

namespace Scripts.Utilies
{
    public static class ItemsToggler
    {
#if UNITY_EDITOR
        [MenuItem("GameObject/Togglers/Add hiding component", priority = 1)]
        static void AddHidingHierarchyScript()
        {
            Utils.ExecuteMenuOnce(() =>
            {
                foreach (var o in Selection.gameObjects)
                    o.AddComponentWithUndo<HideInHierarchy>();
            });
        }

        [MenuItem("GameObject/Togglers/Remove hiding component", priority = 2)]
        static void RemoveHidingHierarchyScript()
        {
            Utils.ExecuteMenuOnce(() =>
            {
                foreach (var o in Selection.gameObjects)
                    o.DestroyComponentWithUndo<HideInHierarchy>();
            });
        }


        [MenuItem("GameObject/Togglers/Show all hidden objects", priority = 4)]
        static void ShowAllHidden()
        {
            Utils.ExecuteMenuOnce(() =>
            {
                HideInHierarchy.SetHidden(false);
            });
        }

        [MenuItem("GameObject/Togglers/Hide all possible objects", priority = 5)]
        static void HideAllHidden()
        {
            Utils.ExecuteMenuOnce(() =>
            {
                HideInHierarchy.SetHidden(true);
            });
        }

        [MenuItem("GameObject/Togglers/Add persistent id", priority = 21)]
        static void AddPersistentId()
        {
            Utils.ExecuteMenuOnce(() =>
            {
                foreach (var o in Selection.gameObjects)
                    o.AddComponentWithUndo<PersistentId>();
            });
        }

        [MenuItem("GameObject/Togglers/Remove persistent id", priority = 22)]
        static void RemovePersistentId()
        {
            Utils.ExecuteMenuOnce(() =>
            {
                foreach (var o in Selection.gameObjects)
                    o.DestroyComponentWithUndo<PersistentId>();
            });
        }
#endif
    }
}
