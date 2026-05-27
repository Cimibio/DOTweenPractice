using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class TextChanger : MonoBehaviour
{
    public enum TextEffectType
    {
        Replacement,
        Addition,
        Hacking
    }

    [Serializable]
    public struct TextStep
    {
        public TextEffectType effectType;
        [TextArea] public string text;
        public float duration;
    }

    [SerializeField] private TextStep[] _steps;
    [SerializeField] private float _delayBetweenSteps = 1f;
    [SerializeField] private Text _textComponent;

    private Sequence _textSequence;
    private string _initialText;
    private string _previousText;

    private void Awake()
    {
        if (_textComponent != null)        
            _initialText = _textComponent.text;        
    }

    private void Start()
    {
        if (_steps == null || _steps.Length == 0 || _textComponent == null) 
            return;

        CreateSequence();
    }

    private void OnDestroy()
    {
        _textSequence?.Kill();
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
                    _textSequence.Append(_textComponent.DOText(_previousText + additionText, step.duration, true, ScrambleMode.None));
                    break;

                case TextEffectType.Hacking:
                    _textSequence.Append(_textComponent.DOText(step.text, step.duration, true, ScrambleMode.All));
                    break;
            }

            _previousText = step.text;
            _textSequence.AppendInterval(_delayBetweenSteps);
        }

        _textSequence.SetLoops(-1)
            .OnStepComplete(ResetText);
    }

    private void ResetText()
    {
        _textComponent.text = _initialText;
    }
}
