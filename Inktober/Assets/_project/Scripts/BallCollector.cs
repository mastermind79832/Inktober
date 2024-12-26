using UnityEngine;

namespace Ottamind.Inktober
{
    public class BallCollector : MonoBehaviour
    {

		private void OnCollisionEnter(Collision collision)
		{
			UIManager.instance.IncreaseScore();
			Destroy(this.gameObject);
		}
	}
}
