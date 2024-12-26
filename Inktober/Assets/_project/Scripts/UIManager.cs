using TMPro;
using UnityEngine;

namespace Ottamind.Inktober
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI ScoreText;
        public int score = 0;

        public static UIManager instance;

		private void Awake()
		{
			instance = this;
		}

		private void Start()
		{
            score = 0;  
			UpdateText();
		}


        public void IncreaseScore()
        {
            score += 1;
            UpdateText ();
        }
		private void UpdateText()
        {
            ScoreText.text = score.ToString();
        }
    }
}
