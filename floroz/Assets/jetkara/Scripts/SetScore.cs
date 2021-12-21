using UnityEngine;

public class SetScore : MonoBehaviour 
{
	public TextMesh bestScoreLabel;
	public TextMesh scoreLabel;

	void Start () 
	{
		scoreLabel.text = "Набрано: " + GameManager.score.ToString();

		if (GameManager.score > 0)
		{
			if (PlayerPrefs.GetInt("Score", 0) < GameManager.score)
			{
				PlayerPrefs.SetInt("Score", GameManager.score);
				PlayerPrefs.Save();
			}
		}

		bestScoreLabel.text = "Максимальный счёт: " + PlayerPrefs.GetInt("Score", 0).ToString();
		GameManager.score = 0;
	}
}