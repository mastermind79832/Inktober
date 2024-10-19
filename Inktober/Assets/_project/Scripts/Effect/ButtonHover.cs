using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

	public float Scale;
	public float Duration;

	public void OnPointerEnter(PointerEventData eventData)
	{
		transform.DOScale(Scale, Duration);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		transform.DOScale(1, Duration);
	}
}
