using System.Collections;
using UnityEngine;

public class JumpTowardsGameObject : MonoBehaviour
{
    [SerializeField, NaughtyAttributes.Required] RuntimeGameObject _target;
    [SerializeField, NaughtyAttributes.Required] Rigidbody2D _body;
    [SerializeField] float _speed;
    [SerializeField] float _interJumpDelay;

    bool _isJumping = false;

    public void ResetJumpFlag() => _isJumping = false;

    IEnumerator JumpTowardsTarget()
    {
        while (true)
        {
            if (_target.Value == null)
            {
                yield return null;
            }
            // Find Player
            var targetPosition = (Vector2) _target.Value.transform.position;
            // Start Jump Animation
            BroadcastMessage("Jump", SendMessageOptions.DontRequireReceiver);
            _isJumping = true;

            BroadcastMessage("LookAtTarget", targetPosition, SendMessageOptions.DontRequireReceiver);

            while (_isJumping)
            {
                yield return new WaitForFixedUpdate();
                var newPosition = Vector2.MoveTowards(_body.position, targetPosition, _speed * Time.fixedDeltaTime);
                _body.MovePosition(newPosition);
            }
            yield return new WaitForSeconds(_interJumpDelay);
        }
    }

    void OnEnable()
    {
        StartCoroutine(JumpTowardsTarget());
    }

    void OnDisable()
    {
        StopAllCoroutines();        
    }
}
