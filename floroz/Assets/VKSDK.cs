using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
//using SimpleJSON;

public class VKSDK : MonoBehaviour
{
    //�������� SINGLETON
    private static VKSDK _instance;

    public static VKSDK Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<VKSDK>();

            return _instance;
        }
    }
    private void Awake()
    {
      //  DontDestroyOnLoad(gameObject); //���� ������ ���� ������ � ��������, ������� �� ������ ������������ �� ����� �����

    }

    UserGameData UGD;
    private UserData UD;

    public UserGameData GetUserGameData => UGD;

    public UserData GetUserData => UD;


    [DllImport("__Internal")]
    private static extern void Auth();    // ����������� - ������� ������� ��� ����� � ��������
    [DllImport("__Internal")]
    private static extern void ShowCommonADV();    // ����� ������� ������� - ������� ������� ��� ����� � ��������
    [DllImport("__Internal")]
    private static extern void GetData();    // ��������� ������ - ������� ������� ��� ����� � ��������
    [DllImport("__Internal")]
    private static extern void SetData(string data);    // �������� ������ - ������� ������� ��� ����� � ��������
    [DllImport("__Internal")]
    private static extern void ShowRewardADV();    // ����� ������� � �������� - ������� ������� ��� ����� � ��������
    [DllImport("__Internal")]
    private static extern void GetLeaderBoardEntries();
    [DllImport("__Internal")]
    private static extern void SetLeaderBoard(int score);



    public event Action AuthSuccess;    //�������
    public event Action DataGet;    //�������
    public event Action RewardGet;  //�������
    public event Action<string> LeaderBoardReady;


    public void Authenticate()    //    �����������
    {
        Auth();
    }

    public void GettingData()    // ��������� ������
    {
        GetData();
    }

    public void SettingData(string data)    // ���������� ������
    {
        SetData(data);
    }

    public void getLeaderEntries()
    {
        GetLeaderBoardEntries();
    }

    public void setLeaderScore(int score)
    {
        SetLeaderBoard(score);
    }

    public void BoardEntriesReady(string _data)
    {
        LeaderBoardReady?.Invoke(_data);
    }

    public void ShowCommonAdvertisment()    // ����� ������� �������
    {
        ShowCommonADV();
    }

    public void ShowRewardAdvertisment()    // ����� ������� � ��������
    {
        ShowRewardADV();
    }


    public void AuthenticateSuccess(string data)    // ����������� ������� ��������
    {
        UD.Name = data;
        AuthSuccess?.Invoke();
    }

    public void DataGetting(string data) // ������ ��������
    {
        UserDataSaving UDS = new UserDataSaving();
        UDS = JsonUtility.FromJson<UserDataSaving>(data);
        UGD = JsonUtility.FromJson<UserGameData>(UDS.data);
        DataGet?.Invoke();
    }

    public void RewardGetting() // ������� �����������
    {
        RewardGet?.Invoke();
    }



}

[Serializable]
public class UserData
{
    public string Name;
    public string image;
}

[Serializable]
public class UserGameData
{
    public UserGameData(int coin)
    {
        Coin = coin;
    }
    public int Coin;
}
[Serializable]
public class UserDataSaving
{
    public string data;
}





