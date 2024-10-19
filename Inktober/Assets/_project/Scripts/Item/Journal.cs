using UnityEngine;

public class Journal : MonoBehaviour
{
	public GameObject JournalDispaly;

	public void ToggleJournalActive()
	{
		JournalDispaly.SetActive(!JournalDispaly.activeSelf);
	}
}
