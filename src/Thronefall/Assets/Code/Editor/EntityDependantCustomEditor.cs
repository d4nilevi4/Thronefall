using Thronefall.Infrastructure;
using UnityEditor;

namespace ThronefallEditor
{
    [CustomEditor(typeof(EntityDependant), editorForChildClasses: true)]
    public class EntityDependantCustomEditor : Editor
    {
        private EntityDependant _entityDependant;

        private void OnEnable()
        {
            _entityDependant = (EntityDependant)target;
            EditorApplication.update += EditorUpdate;
        }

        private void OnDisable()
        {
            EditorApplication.update -= EditorUpdate;
        }

        private void EditorUpdate()
        {
            if(_entityDependant == null || _entityDependant.EntityView != null)
                return;

            _entityDependant.EntityView = _entityDependant.GetComponent<EntityBehaviour>()
                                          ?? _entityDependant.GetComponent<EntityBehaviorProvider>()?.EntityBehaviour;
        }
    }
}