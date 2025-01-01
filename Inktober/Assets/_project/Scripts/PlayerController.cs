using System;
using System.Collections;
using UnityEngine;

namespace Ottamind.Inktober
{
	[SelectionBase]
    public class PlayerController : MonoBehaviour
    {

		private static PlayerController instance;
		public static PlayerController Instance { get { return instance; } }

		public Rigidbody m_Rigidbody;
		public Animator anim;
		public SpriteRenderer spriteRenderer;

		public float Speed;
		public float RotationSpeed;
		public float RotationThreashold;
		public bool IsActionBlocked;

		public float atk1Time;
		public float atk2Time;
		public float atk3Time;

		public Transform Atk1Point;
		public Transform Atk2Point;
		public Transform Atk3Point;

		public InventorySystem InventorySystem;

		private Vector3 m_Direction;
		private Vector3 scaleSave;

		private float m_TargetRotation;
		private bool m_IsRotating;

		private void Awake()
		{
			if (instance == null)
				instance = this;
			else
				Destroy(this);

			scaleSave = spriteRenderer.transform.localScale;
		}

		private void Start()
		{
			m_Direction = new Vector2();
		}

		// Update is called once per frame
		void Update()
		{
			ChangeDirection();
			Movement();
			Attack();
		}

		private void ChangeDirection()
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				m_IsRotating = true;
				m_TargetRotation -= 90;
			}
			else if (Input.GetKeyDown(KeyCode.Q))
			{
				m_IsRotating = true;
				m_TargetRotation += 90;
			}

			if (m_IsRotating)
			{
				transform.eulerAngles = new Vector3(0, Mathf.LerpAngle(transform.eulerAngles.y, m_TargetRotation, RotationSpeed *  Time.deltaTime), 0);

				if (m_TargetRotation > 360)
				{
					m_TargetRotation -= 360;
				}

				if(m_TargetRotation < 0)
				{
					m_TargetRotation += 360;
				}


				if (Mathf.Abs( Mathf.DeltaAngle(transform.eulerAngles.y, m_TargetRotation)) <= RotationThreashold)
				{
					m_IsRotating = false;
					transform.eulerAngles = new Vector3(0, m_TargetRotation, 0);
				}
			}
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
				m_Direction = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
			}
			else
			{
				m_Direction = Vector3.zero;
			}
			m_Rigidbody.linearVelocity = (m_Direction * Speed) + (Physics.gravity);

			SetAnimation();
		}

		private void SetAnimation()
		{
			if (m_Direction == Vector3.zero)
			{
				anim.SetBool("IsRunning", false);
			}
			else
			{
				if (Input.GetAxis("Horizontal") < 0)
				{
					//transform.localScale;
					//spriteRenderer.flipX = true;
					spriteRenderer.transform.localScale = new Vector3(-scaleSave.x, scaleSave.y, scaleSave.z);
				}
				else
				{
					//spriteRenderer.flipX = false;
					spriteRenderer.transform.localScale = new Vector3(scaleSave.x, scaleSave.y, scaleSave.z);
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

		public void TakeDamage(int dmg)
		{
			throw new NotImplementedException();
		}
	}
}
