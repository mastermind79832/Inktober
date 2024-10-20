using UnityEngine;

public class Atk : MonoBehaviour
{

	public string otherTag;
	public int dmg;
	public float force;

	private Vector2 forceDir;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(otherTag))
		{
			collision.GetComponent<IDamageable>().TakeDamage(dmg);
			forceDir = (collision.transform.position - transform.position).normalized;

			collision.GetComponent<Rigidbody2D>().AddForceAtPosition(forceDir * force, transform.position);
			
		}
	}
}
