using DG.Tweening;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _distance = -6;
    [SerializeField] private float _duration = 2f;
    [SerializeField] private int _loopCount = -1;
    [SerializeField] private LoopType _loopType = LoopType.Yoyo;
    [SerializeField] private Ease _ease = Ease.Linear;

    private void Start()
    {
        transform.DOMoveZ(transform.position.z + _distance, _duration)
            .SetLoops(_loopCount, _loopType)
            .SetEase(_ease);
    }
}
