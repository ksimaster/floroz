using UnityEngine;

public class InviteFriend : MonoBehaviour
{
    public GameObject VK;



    void OnMouseDown()
	{
		transform.localScale = new Vector3(0.9f,0.9f,1);
	}
	
	void OnMouseUp()
	{
		transform.localScale = new Vector3(1,1,1);
        //VK.GetComponent<VKSDK>().InviteFriend();
        Application.ExternalEval("InviteFriend();");

    }

    
}
