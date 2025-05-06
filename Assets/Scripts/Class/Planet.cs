using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Planet : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    private void OnMouseDown()
    {
        transform.DOScale(Vector3.one * .8f, .1f).SetEase(Ease.OutSine);
    }

    private void OnMouseUp()
    {
        transform.DOScale(Vector3.one, .1f).SetEase(Ease.OutBack);
    }

    private void OnMouseEnter()
    {
        var currentColor = Color.Lerp(spriteRenderer.color, Color.black, .2f);
        spriteRenderer.DOColor(currentColor, .2f);
    }

    private void OnMouseExit()
    {
        spriteRenderer.DOColor(Color.white, .2f);
    }
}
