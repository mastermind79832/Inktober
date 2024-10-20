using System;
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
		throw new NotImplementedException();
	}

	private void Movement()
	{
		m_Direction = Vector2.right * Input.GetAxis("Horizontal") + Vector2.up * Input.GetAxis("Vertical");

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
}
