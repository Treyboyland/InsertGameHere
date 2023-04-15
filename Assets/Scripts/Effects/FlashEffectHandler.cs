using UnityEngine;

public class FlashEffectHandler : MonoBehaviour
{
    [SerializeField, NaughtyAttributes.Required] SpriteRenderer _spriteRenderer;
    [SerializeField, Range(0, 1)] float _flashAmount;
    [SerializeField] Color _flashColor = Color.white;
    [SerializeField] string _flashAmountParam = "_FlashAmount";
    [SerializeField] string _flashColorParam = "_FlashColor";

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _spriteRenderer.material.SetColor(_flashColorParam, _flashColor);
        _spriteRenderer.material.SetFloat(_flashAmountParam, _flashAmount);
    }
}
