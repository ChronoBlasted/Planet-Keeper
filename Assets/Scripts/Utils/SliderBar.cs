using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Slider delayedSlider;
    [SerializeField] Slider recoverSlider;

    Tweener _fillTween;
    Tweener _fillDelayedTween;
    Tweener _fillRecoverTween;


    public void Init(float value, float maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = value;

        delayedSlider.maxValue = maxValue;
        delayedSlider.value = value;

        recoverSlider.maxValue = maxValue;
        recoverSlider.value = value;
    }

    public void Init(float value)
    {
        Init(value, value);
    }

    public void SetValue(float newValue)
    {
        slider.value = newValue;
        delayedSlider.value = newValue;
        recoverSlider.value = newValue;
    }

    public void SetMaxValue(float newValue)
    {
        slider.maxValue = newValue;
        delayedSlider.maxValue = newValue;
        recoverSlider.maxValue = newValue;
    }

    public void SetValueSmooth(float newValue, float duration = 0.2f, float delay = 0f, Ease ease = Ease.OutCirc)
    {
        if (_fillTween != null)
        {
            _fillTween.Kill(true);
            _fillTween = null;
        }

        if (_fillDelayedTween != null)
        {
            _fillDelayedTween.Kill();
            _fillDelayedTween = null;
        }

        if (_fillRecoverTween != null)
        {
            _fillRecoverTween.Kill();
            _fillRecoverTween = null;
        }

        if (newValue > slider.value)
        {
            _fillRecoverTween = recoverSlider.DOValue(newValue, duration).SetDelay(delay).SetEase(ease);

            _fillTween = slider.DOValue(newValue, duration * 2f).SetDelay(delay).SetEase(Ease.Linear);
            _fillDelayedTween = delayedSlider.DOValue(newValue, duration * 2f).SetDelay(delay).SetEase(Ease.Linear);
        }
        else
        {
            _fillTween = slider.DOValue(newValue, duration).SetDelay(delay).SetEase(ease);
            _fillRecoverTween = recoverSlider.DOValue(newValue, duration).SetDelay(delay).SetEase(ease);

            _fillDelayedTween = delayedSlider.DOValue(newValue, duration * 2f).SetDelay(delay).SetEase(Ease.Linear);
        }
    }
}