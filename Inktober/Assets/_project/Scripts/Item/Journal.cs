using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct PageSet
{
	public GameObject Page1;
	public GameObject Page2;
}

public class Journal : MonoBehaviour
{
	public GameObject JournalDispaly;
	public PageSet[] PageSets;

	public int CurrentPageSet;

	private void Start()
	{
		CurrentPageSet = 0;
		EnablePage(CurrentPageSet);
	}

	public void EnablePage(int pageNo)
	{
		foreach (PageSet Pg in PageSets)
		{
			Pg.Page1.SetActive(false);
			Pg.Page2.SetActive(false);
		}

		PageSets[pageNo].Page1.SetActive(true);
		PageSets[pageNo].Page2.SetActive(true);

	}

	private void Update()
	{
		if (!JournalDispaly.activeSelf)
			return;

		// Back Page
		if (Input.GetKeyDown(KeyCode.Q))
		{
			BackPage();
		}

		// Next Page
		if (Input.GetKeyDown(KeyCode.E))
		{
			NextPage();
		}
	}

	public void NextPage()
	{
		if (CurrentPageSet + 1 < PageSets.Length)
		{
			CurrentPageSet += 1;
			EnablePage(CurrentPageSet);
		}
	}

	public void BackPage()
	{
		if (CurrentPageSet - 1 >= 0)
		{
			CurrentPageSet -= 1;
			EnablePage(CurrentPageSet);
		}
	}

	public void ToggleJournalActive()
	{
		JournalDispaly.SetActive(!JournalDispaly.activeSelf);
	}
}
