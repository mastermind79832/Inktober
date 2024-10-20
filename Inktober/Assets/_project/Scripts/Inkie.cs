using System;
using System.Collections;
using UnityEngine;

public class Inkie : MonoBehaviour, IDamageable
{
	[SerializeField] private Animator animator;

	[Header("Properties")]
	[SerializeField] private int maxHealth;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float deathTime;

	[Header("Atk")]
	[SerializeField] private int damageAmount;
	[SerializeField] private float AttackRange;
	[SerializeField] private float AtkTime;

	private int health;
	private bool isAttacking;
	private bool isDead;

	private void Start()
	{
		health = maxHealth;
		isAttacking = false;
	}


	private void Update()
	{
		// don't do anything while attacking
		if (isAttacking || isDead)
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

	public void TakeDamage(int dmg)
	{

		health-= dmg;

		if (health <= 0)
		{
			StopAllCoroutines();
			StartCoroutine(DeathRoutine());
		}
	}
	private IEnumerator DeathRoutine()
	{
		isDead = true;
		animator.SetTrigger("IsDead");
		yield return new WaitForSeconds(deathTime);
		Destroy(gameObject);
	}
}
