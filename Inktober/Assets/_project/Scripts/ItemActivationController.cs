using UnityEngine;
using static UnityEditor.Progress;

public class ItemActivationController : MonoBehaviour
{
    public static ItemActivationController Instance { get; private set; }

	public bool IsJournalAquired;
    public bool IsBackPackAcquired;
    public bool IsBrushAcquired;

	public Journal Journal;
	
	private void Awake()
	{
		Instance = this;
	}


	private void Update()
	{
		SetJournal();
	}

	private void SetJournal()
	{
		if (Input.GetKeyDown(KeyCode.J) && IsJournalAquired)
		{
			Journal.ToggleJournalActive();
		}
	}

	private bool JournalAquired()
	{
		if (IsBackPackAcquired)
		{
			IsJournalAquired = true;
			Debug.Log("Journal collected");
			return true;
		}
		Debug.Log("Bag needed");
		return false;
		//popup
	}

	private bool BackpackAquired()
	{ 
		Debug.Log("Bag collected");
		IsBackPackAcquired = true;
		return true;
	}

	private bool BrushAquired()
	{
		if (IsBackPackAcquired)
		{
			Debug.Log("Brush collected");
			IsBrushAcquired = true;
			return true;
		}
		Debug.Log("Bag needed");
		return false;
	}

	public void ItemAcquired(Item item)
	{
		bool isAcquired = false;
		switch(item.ItemName)
		{
			case ItemName.Journal:
				isAcquired = JournalAquired();
				break;

			case ItemName.Backpack:
				isAcquired = BackpackAquired();
				break;

			case ItemName.Brush:
				isAcquired = BrushAquired();
				break;

			default: break;
		}

		if (isAcquired) 
			Destroy(item.gameObject);
	}
}
