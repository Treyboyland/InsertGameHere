using UnityEngine;

namespace rho
{
    public class AddGameObjectToRuntimeSet : MonoBehaviour
    {
        [SerializeField] RuntimeGameObjectSet _runtimeSet = null;

        // Start is called before the first frame update
        void OnEnable()
        {
            _runtimeSet?.Add(this.gameObject);
        }

        // Update is called once per frame
        void OnDisable()
        {
            _runtimeSet?.Remove(this.gameObject);
        }
    }
}