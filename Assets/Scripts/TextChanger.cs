using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextChanger : MonoBehaviour
{
    public enum TextEffectType
    {
        Replacement = 1, // Ёффект замены
        Addition = 2,    // Ёффект добавлени€
        Hacking = 3      // Ёффект хакерского перебора
    }

    [System.Serializable]
    public struct TextStep
    {
        public TextEffectType effectType; // ¬ыбор эффекта (1, 2 или 3)
        [TextArea] public string text;     // “екст дл€ этого шага (больше никаких плюсов писать не нужно!)
        public float duration;             // ƒлительность анимации
    }

    [SerializeField] private TextStep[] _steps;
    [SerializeField] private float _delayBetweenSteps = 1f;
    [SerializeField] private Text _textComponent;

    private Sequence _textSequence;
    private string _initialText;

    private void Awake()
    {
        if (_textComponent != null)
        {
            _initialText = _textComponent.text;
        }
    }

    private void Start()
    {
        if (_steps == null || _steps.Length == 0 || _textComponent == null) return;

        CreateSequence();
    }

    private void CreateSequence()
    {
        _textSequence = DOTween.Sequence();

        for (int i = 0; i < _steps.Length; i++)
        {
            TextStep step = _steps[i];

            switch (step.effectType)
            {
                case TextEffectType.Replacement:
                    _textSequence.Append(_textComponent.DOText(step.text, step.duration, true, ScrambleMode.None));
                    break;

                case TextEffectType.Addition:
                    string additionText = "+" + step.text;
                    _textSequence.Append(_textComponent.DOText(additionText, step.duration, true, ScrambleMode.None));
                    break;

                case TextEffectType.Hacking:
                    _textSequence.Append(_textComponent.DOText(step.text, step.duration, true, ScrambleMode.All));
                    break;
            }

            _textSequence.AppendInterval(_delayBetweenSteps);
        }

        _textSequence.SetLoops(-1)
            .OnStepComplete(() =>
            {
                _textComponent.text = _initialText;
            });
    }

    private void OnDestroy()
    {
        _textSequence?.Kill();
    }
}
