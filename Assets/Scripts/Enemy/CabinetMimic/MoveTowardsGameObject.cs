using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsGameObject : MonoBehaviour
{
    [SerializeField, NaughtyAttributes.Required] RuntimeGameObject _target;
    [SerializeField, NaughtyAttributes.Required] Rigidbody2D _body;
    [SerializeField] float _speed;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (_target.Value != null)
            {
                var targetTransform = _target.Value.transform;
                var newPosition = Vector2.MoveTowards(_body.position, targetTransform.position, _speed * Time.fixedDeltaTime);
                _body.MovePosition(newPosition);
            }
        }
    }
}
