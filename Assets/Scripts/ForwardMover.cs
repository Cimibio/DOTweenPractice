using DG.Tweening;
using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    [SerializeField] private Vector3 _direction = Vector3.forward;
    [SerializeField] private float _distance = 6;
    [SerializeField] private float _duration = 2f;
    [SerializeField] private int _loopCount = -1;
    [SerializeField] private LoopType _loopType = LoopType.Yoyo;
    [SerializeField] private Ease _ease = Ease.Linear;

    private Vector3 _directionOffset;

    private void Awake()
    {
        CalcutaleDirectionOffset();
    }

    private void Start()
    {
        Move();
    }

    private void Move()
    {
        transform.DOBlendableLocalMoveBy(_directionOffset, _duration)
            .SetLoops(_loopCount, _loopType)
            .SetEase(_ease);
    }

    private void CalcutaleDirectionOffset()
    {
        _directionOffset = _direction * _distance;
    }
}
