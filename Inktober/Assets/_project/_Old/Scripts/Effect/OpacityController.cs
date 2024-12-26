using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent (typeof(Collider2D))]
public class OpacityController : MonoBehaviour
{
	public SpriteRenderer SpriteRenderer;
	public float Alpha = 1.0f;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<PlayerController>())
		{
			SpriteRenderer.color -= new Color(0, 0, 0, Alpha);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.GetComponent<PlayerController>())
		{
			SpriteRenderer.color += new Color(0, 0, 0, Alpha);
		}
	}
}
