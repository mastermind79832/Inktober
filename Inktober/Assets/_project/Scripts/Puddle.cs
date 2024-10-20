using UnityEngine;

public class Puddle : MonoBehaviour
{
	public Inkie InkiePrefab;
	public Transform[] SpawnPoints;
	public float SpawnInterval;
	public float playerRange;

	private float time;

	private void Update()
	{
		// if player not in range. Dont do anything
		if (!(Vector2.Distance(PlayerController.Instance.transform.position, transform.position) <= playerRange))
			return;
		RunTimer();
	}

	private void RunTimer()
	{
		if (time >= SpawnInterval)
		{
			time = 0;
			SpawnNewInkie();
		}
		else
		{
			time += Time.deltaTime;
		}
	}

	private void SpawnNewInkie()
	{
		Vector2 pos = GetRandomPos();
		Instantiate(InkiePrefab,pos,Quaternion.identity);
	}

	private Vector2 GetRandomPos()
	{
		return SpawnPoints[Random.Range(0, SpawnPoints.Length)].position;
	}
}
