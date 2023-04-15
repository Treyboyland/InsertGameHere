using UnityEngine;

public class FlashEffectHandler : MonoBehaviour
{
    [SerializeField, NaughtyAttributes.Required] SpriteRenderer _spriteRenderer;
    Color _tint = Color.white;
    [SerializeField, Range(0, 1)] float _flashAmount;
    [SerializeField] Color _flashColor = Color.white;
    [SerializeField] string _flashAmountParam = "_FlashAmount";
    [SerializeField] string _flashColorParam = "_FlashColor";
    [SerializeField] string _tintParam = "_Tint";

    void Update()
    {
        // If the sprite renderer is never not white, then steal that color and use it as tint
        if (_spriteRenderer.color != Color.white)
        {
            _tint = _spriteRenderer.color;
            _spriteRenderer.color = Color.white;
        }
        
        _spriteRenderer.material.SetColor(_flashColorParam, _flashColor);
        _spriteRenderer.material.SetFloat(_flashAmountParam, _flashAmount);
        _spriteRenderer.material.SetColor(_tintParam, _tint);
    }
}
