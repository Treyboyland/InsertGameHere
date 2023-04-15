using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FlashEffectHandler : MonoBehaviour
{
    [SerializeField, Range(0, 1)] float _flashAmount;
    [SerializeField] Color _flashColor = Color.white;
    [SerializeField] string _flashAmountParam = "_FlashAmount";
    [SerializeField] string _flashColorParam = "_FlashColor";

    SpriteRenderer _spriteRenderer;

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
