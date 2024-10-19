using UnityEngine;

public class PlayerController : MonoBehaviour
{ 

	private static PlayerController instance;
	public static PlayerController Instance { get { return instance; } }	

    private Vector2 m_Direction;
	public Rigidbody2D Rigidbody2D;
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
	}

	private void Movement()
	{
		m_Direction = Vector2.right * Input.GetAxis("Horizontal") + Vector2.up * Input.GetAxis("Vertical");

		//if (m_Direction == Vector2.zero)
			//return;
		Rigidbody2D.linearVelocity = m_Direction * Speed;
	}
}
