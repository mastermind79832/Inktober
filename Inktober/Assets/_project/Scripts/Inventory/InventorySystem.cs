using UnityEngine;

public class InventorySystem : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Item item))
		{
			ItemActivationController.Instance.ItemAcquired(item);
		}
	}
}
