using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 

	private static PlayerController instance;
	public static PlayerController Instance { get { return instance; } }	

    private Vector2 m_Direction;
	public Rigidbody2D Rigidbody2D;
	public Animator anim;
	public SpriteRenderer spriteRenderer;

	public float Speed;
	public bool IsActionBlocked;

	public float atk1Time;
	public float atk2Time;
	public float atk3Time;

	public InventorySystem InventorySystem;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(this);	
	}

	private void Start()
	{
		m_Direction = new Vector2();
	}

	// Update is called once per frame
	void Update()
	{
		Movement();
		Attack();
	}

	private void Attack()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			anim.SetTrigger("Atk1");
			BlockAction(atk1Time);
		}

		if (Input.GetKeyDown(KeyCode.L))
		{
			anim.SetTrigger("Atk2");
			BlockAction(atk2Time);
		}

		if (Input.GetKeyDown(KeyCode.Semicolon))
		{
			anim.SetTrigger("Atk3");
			BlockAction(atk3Time);
		}
	}

	private void Movement()
	{
		if (!IsActionBlocked)
		{
			m_Direction = Vector2.right * Input.GetAxis("Horizontal") + Vector2.up * Input.GetAxis("Vertical");
		}
		else
		{
			m_Direction = Vector2.zero;
		}
			Rigidbody2D.linearVelocity = m_Direction * Speed;

		SetAnimation();
	}

	private void SetAnimation()
	{
		if (m_Direction == Vector2.zero)
		{
			anim.SetBool("IsRunning", false);
		}
        else
        {
			if (m_Direction.x < 0)
			{
				spriteRenderer.flipX = true;
			}
			else
			{
				spriteRenderer.flipX = false;
			}

			anim.SetBool("IsRunning", true);
		}
	
    }

	private void BlockAction(float amt)
	{
		StartCoroutine(BlockActionRoutine(amt));
	}

	IEnumerator BlockActionRoutine(float amt)
	{
		IsActionBlocked = true;
		yield return new WaitForSeconds(amt);
		IsActionBlocked = false;
	}
}
