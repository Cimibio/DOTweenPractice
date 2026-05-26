using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationDirection;
    [SerializeField] private float _duration = 2f;
    [SerializeField] private int _loopCount = -1;
    [SerializeField] private LoopType _loopType = LoopType.Incremental;
    [SerializeField] private Ease _ease = Ease.Linear;

    private void Start()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.DOLocalRotate(_rotationDirection, _duration, RotateMode.FastBeyond360)
            .SetLoops(_loopCount, _loopType)
            .SetEase(_ease);
    }
}
