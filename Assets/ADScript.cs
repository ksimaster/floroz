using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ADScript : MonoBehaviour
{
    /*
	public Slider sliderHome;
	public Slider sliderFuelCar;
	public float rewardBonusSliderHome;
	public float rewardBonusSliderFuel;
	public float lowBalanceFuel;
    */
    public void ShareFriend(){
#if UNITY_WEBGL && !UNITY_EDITOR
        WebGLPluginJS.ShareFunction();
#endif
    }

    public void ShowAdInterstitial(){
#if UNITY_WEBGL && !UNITY_EDITOR
    	WebGLPluginJS.InterstitialFunction();
#endif
    }

    public void ShowAdReward(){
#if UNITY_WEBGL && !UNITY_EDITOR
    	WebGLPluginJS.RewardFunction();
#endif
       // sliderHome.value += rewardBonusSliderHome;
    	//if(sliderFuelCar.value<=lowBalanceFuel) sliderFuelCar.value += rewardBonusSliderFuel;
    }

    void OnMouseDown()
    {
        transform.localScale = new Vector3(0.9f, 0.9f, 1);
    }

    void OnMouseUp()
    {
        transform.localScale = new Vector3(1, 1, 1);
        //VK.GetComponent<VKSDK>().InviteFriend();
        ShareFriend();

    }

    private void Update()
    {
       // if (sliderHome.value <= sliderHome.minValue) ShowAdInterstitial();
    }
}