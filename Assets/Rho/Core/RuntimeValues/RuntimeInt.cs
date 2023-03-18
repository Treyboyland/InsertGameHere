using UnityEngine;

namespace rho
{
    [CreateAssetMenu(fileName = "RuntimeIntValue", menuName = "Rho/RuntimeValues/Int")]
    public class RuntimeInt : RuntimeValue<int>
    {
        public void Modify(int magnitude) => Value += magnitude;
    }
}