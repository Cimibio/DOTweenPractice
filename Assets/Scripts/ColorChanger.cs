using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color _targetColor = Color.red;
    [SerializeField] private float _duration = 2f;
    [SerializeField] private int _loopCount = -1;
    [SerializeField] private LoopType _loopType = LoopType.Yoyo;
    [SerializeField] private Ease _ease = Ease.Linear;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        _renderer.material.DOColor(_targetColor, _duration)
            .SetLoops(_loopCount, _loopType)
            .SetEase(_ease);
    }
}
