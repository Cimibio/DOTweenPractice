using DG.Tweening;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _scaleMultiplier = 2f;
    [SerializeField] private float _duration = 3f;
    [SerializeField] private int _loopCount = -1;
    [SerializeField] private LoopType _loopType = LoopType.Yoyo;
    [SerializeField] private Ease _ease = Ease.Linear;

    private void Start()
    {
        Scale();
    }

    private void Scale()
    {
        transform.DOScale(_scaleMultiplier, _duration)
            .SetLoops(_loopCount, _loopType)
            .SetEase(_ease);
    }
}
