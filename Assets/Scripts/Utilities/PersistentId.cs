using System;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Scripts.Utilies
{
    [ExecuteInEditMode]
    public class PersistentId : MonoBehaviour
    {
        [SerializeField]
        private string id;

        // Public getter to read the ID from other scripts
        public string Id => id;

        // Called when the script is first added or reset in the inspector
        private void Reset()
        {
            GenerateId();
        }

        // Called automatically in the editor when script loads or values change
        private void OnValidate()
        {
#if UNITY_EDITOR
            // If the ID is empty (e.g., newly created or instantiated)
            if (string.IsNullOrEmpty(id))
            {
                GenerateId();
            }
#endif
        }

        private void GenerateId()
        {
            id = Guid.NewGuid().ToString();

#if UNITY_EDITOR
            // Tell Unity's undo/save system that the component has changed
            if (!Application.isPlaying)
            {
                UnityEditor.EditorUtility.SetDirty(gameObject);
            }
#endif
        }
    }
}
