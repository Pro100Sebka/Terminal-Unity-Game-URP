using System;
using UnityEngine;
using TMPro;

public class ValueManager : MonoBehaviour
{
    private float USD;
    private float BTC;
    private float MoneyPerClick;
    [SerializeField] private TextMeshProUGUI text;

    public void Start()
    {
        LoadData();
        UpdateText();
    }

    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            USD += MoneyPerClick;
            UpdateText();
            SaveData();
        }
    }

    public void UpdateText()
    {
        text.text =
            "Balance = <color=#62e841><b> "+USD+"$</b></color>\nPerSpace = <color=#62e841><b> "+MoneyPerClick+"$</b></color>\n" +
            "<color=#ffc400><b>BTC</b></color> =<color=#ffc400><b> "+ BTC +"</b></color>\n" +
            "---------------------------"+
            "\n<color=#ffc400><b>1 BTC</b></color> = <color=#62e841><b>0.001$</b></color>";
    }

    private void SaveData()
    {
        PlayerPrefs.SetFloat("BTC", BTC);
        PlayerPrefs.SetFloat("USD", USD);
        PlayerPrefs.SetFloat("MoneyPerClick", MoneyPerClick);
        
        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        BTC = PlayerPrefs.GetFloat("BTC", 0f);
        USD = PlayerPrefs.GetFloat("USD", 0f);
        MoneyPerClick = PlayerPrefs.GetFloat("MoneyPerClick", 1f);
    }
}