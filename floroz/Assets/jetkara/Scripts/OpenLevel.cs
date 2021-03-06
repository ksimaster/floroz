using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour 
{
	public string levelName;
    public GameObject Yandex;

	void OnMouseDown()
	{
		transform.localScale = new Vector3(0.9f,0.9f,1);
	}
	
	void OnMouseUp()
	{
		transform.localScale = new Vector3(1,1,1);
       if(levelName == "MainMenu") Yandex.GetComponent<YandexSDK>().ShowInterstitial();
        SceneManager.LoadScene(levelName);
	}
}
