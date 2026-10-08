using UnityEngine;
using UnityEditor;

namespace Unity.Utilities
{
    public class HideInHierarchy : MonoBehaviour
    {
        const string HiddenPrefs = "hierarchyhidden";

        private void OnValidate()
        {
            SetHidden(myself: gameObject);
        }

        public static void SetHidden(bool? hidden = null, GameObject myself = null)
        {
#if UNITY_EDITOR
            if (hidden.HasValue)
            {
                EditorPrefs.SetBool(HiddenPrefs, hidden.Value);
            }
            else
            {
                hidden = EditorPrefs.GetBool(HiddenPrefs, false);
            }
            if (myself != null)
            {
                myself.hideFlags = hidden.Value ? HideFlags.HideInHierarchy : HideFlags.None;
            }
            else
            {
                foreach (var o in GameObject.FindObjectsByType<HideInHierarchy>())
                    o.gameObject.hideFlags = hidden.Value ? HideFlags.HideInHierarchy : HideFlags.None;
            }
#endif
        }
    }
}