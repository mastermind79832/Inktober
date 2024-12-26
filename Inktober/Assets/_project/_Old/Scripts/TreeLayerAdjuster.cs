using UnityEngine;
using UnityEngine.Rendering;

public class TreeLayerAdjuster : MonoBehaviour
{

    private PlayerController player;
    private float offset;
    private SpriteRenderer spriteRenderer;

    public float OffsetThreshold;
    public int DefaultOrder;
    public int Order;
    
    void Start()
    {

        player = PlayerController.Instance;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            offset = player.transform.position.y - transform.position.y;   

            if (offset < OffsetThreshold)
			{
				SetRenderOrder(Order);
			}
			else
            {
				SetRenderOrder(DefaultOrder);
			}
        }
        else
        {
            Debug.Log(gameObject.name + ": Player not found");
        }
    }

	private void SetRenderOrder(int order)
	{
		if (spriteRenderer)
		{
			spriteRenderer.sortingOrder = order;
		}
		else
		{
			Debug.Log(gameObject.name + ": SpriteRender not found");
		}
	}
}
