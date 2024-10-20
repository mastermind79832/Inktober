using System.Collections;
using UnityEngine;

public class Inkie : MonoBehaviour
{
	[SerializeField] private Animator animator;

	[Header("Properties")]
	[SerializeField] private int maxHealth;
	[SerializeField] private float moveSpeed;

	[Header("Atk")]
	[SerializeField] private int damageAmount;
	[SerializeField] private float AttackRange;
	[SerializeField] private float AtkTime;

	private int health;
	private bool isAttacking;

	private void Start()
	{
		health = maxHealth;
		isAttacking = false;
	}

	public void TakeDamage()
	{
		health--;

		if (health <= 0)
		{ 
			Destroy(gameObject);
		}
	}

	private void Update()
	{
		// don't do anything while attacking
		if (isAttacking)
			return;

		//transform.DOMove(PlayerController.Instance.transform.position, moveSpeed * Time.deltaTime);
		transform.position = Vector2.MoveTowards(transform.position, PlayerController.Instance.transform.position, moveSpeed * Time.deltaTime);

		// check if player is in range
		if (Vector2.Distance(PlayerController.Instance.transform.position, transform.position) <= AttackRange)
		{
			Attack();
		}
	}

	private void Attack()
	{
		animator.SetTrigger("Atk");
		StartCoroutine(AtkRoutine());
	}

	private IEnumerator AtkRoutine()
	{
		isAttacking = true;
		yield return new WaitForSeconds(AtkTime);
		isAttacking = false;
	}
}
