using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector2 m_Direction;
	public Rigidbody2D Rigidbody2D;
	public float Speed;

	public GameObject Journal;

	private void Start()
	{
		m_Direction = new Vector2();
	}

	// Update is called once per frame
	void Update()
	{
		Movement();
		SetJournal();
	}

	private void SetJournal()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			Journal.SetActive(!Journal.activeSelf);
		}
	}

	private void Movement()
	{
		m_Direction = Vector2.right * Input.GetAxis("Horizontal") + Vector2.up * Input.GetAxis("Vertical");

		if (m_Direction == Vector2.zero)
			return;
		Rigidbody2D.linearVelocity = m_Direction * Speed;
	}
}
