using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;
using System.Threading;

public class TextBox : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI textUnder;
    [SerializeField] private TextMeshProUGUI placeHolder;
    [SerializeField] private TextMeshProUGUI outputText;
    [SerializeField] private GameObject blueScreen;
    [SerializeField] private AudioSource blueScreenAudio;
    [SerializeField] private AudioSource keyboardSound;
    [SerializeField] private AudioSource enterSound;
    public static Color everythingColor;
    private int intnumber;
    public int balance; 
    public string colorTwo;

    
    private void Start()
    {
        LoadData();
        print(everythingColor);
        outputText.color = everythingColor;
        placeHolder.color = everythingColor;
        textUnder.color = everythingColor;
        text.color = everythingColor;
        inputField.ActivateInputField();
    }
    
    
    string RGBToHTML(int r, int g, int b)
    {
        float rf = r / 255f;
        float gf = g / 255f;
        float bf = b / 255f;
        
        Color color = new Color(rf, gf, bf);
        string htmlColor = ColorUtility.ToHtmlStringRGB(color);

        return htmlColor;
    }

    public void OnInputValueChanged()
    {
        keyboardSound.Play();
    }
    
    public void ClearLastLine()
    {
        string[] lines = outputText.text.Split('\n');
        if (lines.Length > 2)
        {
            outputText.text = string.Join("\n", lines.Take(lines.Length - 2));
        }
        else
        {
            outputText.text = "";
        }
    }
    
    private void OnApplicationQuit()
    {
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetString("text", outputText.text);
        
        PlayerPrefs.SetInt("balance", balance);
        
        PlayerPrefs.SetString("colorTwo", colorTwo);
        
        PlayerPrefs.SetFloat("color_r", everythingColor.r);
        PlayerPrefs.SetFloat("color_g", everythingColor.g);
        PlayerPrefs.SetFloat("color_b", everythingColor.b);
        
        PlayerPrefs.Save();
    }
    private void LoadData()
    {
        outputText.text = PlayerPrefs.GetString("text", "Hello User its a terminal, type Help to familiarize here!" + "\n");
        
        colorTwo = PlayerPrefs.GetString("colorTwo", "#FFFFFF");
        
        balance = PlayerPrefs.GetInt("balance", 0);
        
        float r = PlayerPrefs.GetFloat("color_r", 1f);
        float g = PlayerPrefs.GetFloat("color_g", 1f);
        float b = PlayerPrefs.GetFloat("color_b", 1f);
        everythingColor = new Color(r, g, b);

        outputText.color = everythingColor;
        placeHolder.color = everythingColor;
        textUnder.color = everythingColor;
        text.color = everythingColor;
        
        print("loadingdata" + everythingColor);
    }
    
    IEnumerator Mine(int intnumber)
    {
        for (int i = 0; i < intnumber; i++)
        {
            balance++;
            outputText.text = outputText.text + "\n" + "balance = " + this.balance + " Usd" + "\n";
            yield return new WaitForSeconds(5);
            SaveData();
        }
    }



    public void OnEnd()
    {
        if(Input.GetMouseButton(0)) return;
        SaveData();
        print(everythingColor);
        keyboardSound.Play();
        inputField.text = inputField.text.ToLower();

        if (inputField.text == "error")
        {
            blueScreen.SetActive(true);
            blueScreenAudio.Play();
            Thread.Sleep(2000);
            Application.Quit();
        }
        else if (inputField.text == "balance")
        {
            outputText.text = outputText.text + "\n" + "balance = " + balance + " Usd" + "\n";
        }
        else if (inputField.text == "help")
        {
            outputText.text = outputText.text 
                              + "\n" + "<color=#9c2dcc><size=120%><b>Commands</b></size></color>"
                              + "\n" + "help            |   <color=#ffc400><B>Prints this message<B></color>"
                              + "\n"
                              + "\n" + "<color=#d14b93><size=120%><b>Printing</b></size></color>"
                              + "\n" + "print(message)  |   <color=#ffc400><B>Prints your message<B></color>"
                              + "\n" + "figlet()        |   <color=#ffc400><B>Prints big message with third color<B></color>"
                              + "\n"
                              + "\n" + "<color=#59ffe3><size=120%><b>Apearence</b></size></color>"
                              + "\n" + "colortwo(r,g,b) |   <color=#ffc400><B>Makes third color for figlet<B></color>"
                              + "\n" + "color(r,g,b)    |   <color=#ffc400><B>Change color of text<B></color>"
                              + "\n"
                              + "\n" + "<color=#5964ff><size=120%><b>Programs</b></size></color>"
                              + "\n" + "showprograms    |   <color=#ffc400><B>Prints all games<B></color>"
                              + "\n" + "open()          |   <color=#ffc400><B>Playing games<B></color>"
                              + "\n"
                              + "\n" + "<color=#59ff5c><size=120%><b>Money</b></size></color>"
                              + "\n" + "mine(number)    |   <color=#ffc400><B>Mining USD<B></color>"
                              + "\n" + "balance         |   <color=#ffc400><B>Shows you balance in USD<B></color>"
                              + "\n"
                              + "\n" + "<color=#f57ac0><size=120%><b>Other</b></size></color>"
                              + "\n" + "savedata        |   <color=#ffc400><B>Saving your data<B></color>"
                              + "\n" + "shutdown        |   <color=#ffc400><B>ShutDown Console<B></color>"
                              + "\n" + "cls             |   <color=#ffc400><B>Clear all your messages<B></color>"
                              + "\n" + "clslast         |   <color=#ffc400><B>Clear your last line<B></color>"
                              + "\n" + "error           |   <color=#ffc400><B>Error<B></color>"
                              + "\n";
        }
        
        else if (inputField.text == "shutdown")
        {
            outputText.text = outputText.text + "\n" + "Shutdowns..." + "\n";
            Application.Quit();
        }
        
        else if (inputField.text == "showprograms")
        {
            outputText.text = outputText.text + "\n" + "<size=130%><color=#ffc400><B>Games</B></color></size>" + "\n" + "tetris, pingpong, miningsimulator " + "\n";
        }
        
        else if (inputField.text == "cls")
        {
            outputText.text = "\n";
        }
        
        else if (inputField.text == "clslast")
        {
            ClearLastLine();
        }
        
        else if (inputField.text == "savedata")
        {
            SaveData();
            outputText.text = outputText.text + "\n" + "Data Saved!" + "\n";
        }

        else if (inputField.text.StartsWith("mine(") && inputField.text.EndsWith(")"))
        {
            string number = inputField.text.Substring(5, inputField.text.Length - 6);
            StartCoroutine(Mine(int.Parse(number) + 1));
            outputText.text = outputText.text + "\n" + "mining..." + "\n";
        }
        else if (inputField.text.StartsWith("print(") && inputField.text.EndsWith(")"))
        {
            string message = inputField.text.Substring(6, inputField.text.Length - 7);
            outputText.text = outputText.text + "\n" + message + "\n";
        }
        
        else if (inputField.text.StartsWith("figlet(") && inputField.text.EndsWith(")"))
        {
            string message = inputField.text.Substring(7, inputField.text.Length - 8);
            outputText.text = outputText.text + "\n" + "<size=130%><color=#" + colorTwo + "><b>" + message + "</b></color></size>" + "\n";
        }
        
        else if (inputField.text.StartsWith("open(") && inputField.text.EndsWith(")"))
        {
            string gameName = inputField.text.Substring(5, inputField.text.Length - 6);
            switch (gameName)
            {
                case "tetris":
                    SceneManager.LoadScene("Tetris");
                    break;
                case "pingpong":
                    SceneManager.LoadScene("PingPong");
                    break;
                case "miningsimulator":
                    SceneManager.LoadScene("MiningSimulator");
                    break;
            }
        }
        else if (inputField.text.StartsWith("colortwo(") && inputField.text.EndsWith(")"))
        {
            string colortwo = inputField.text.Substring(9, inputField.text.Length - 10); // Adjusted substring length
            string[] rgbValues = colortwo.Split(',');
            if (rgbValues.Length == 3)
            {
                float r, g, b;
                if (float.TryParse(rgbValues[0], out r) &&
                    float.TryParse(rgbValues[1], out g) &&
                    float.TryParse(rgbValues[2], out b))
                {
                    string htmlColor = RGBToHTML((int)r, (int)g, (int)b);

                    this.colorTwo = htmlColor;
                    SaveData();
                    
                    outputText.text = outputText.text + "\n" + "Done, new colortwo: " + this.colorTwo + "\n";
                }
                else 
                {
                    outputText.text = outputText.text + "\n" + "Error converting RGB values to numbers" + "\n";
                }
            }
            else 
            {
                outputText.text = outputText.text + "\n" + "Incorrect RGB string format" + "\n";
            }
        }
        
        else if (inputField.text.StartsWith("color(") && inputField.text.EndsWith(")"))
        {
            string color = inputField.text.Substring(6, inputField.text.Length - 7);
            string[] rgbValues = color.Split(',');
            if (rgbValues.Length == 3)
            {
                float r, g, b;
                if (float.TryParse(rgbValues[0], out r) &&
                    float.TryParse(rgbValues[1], out g) &&
                    float.TryParse(rgbValues[2], out b))
                {
                    Color colorTwo = new Color(r / 255f, g / 255f, b / 255f);
                    outputText.color = colorTwo;
                    placeHolder.color = colorTwo;
                    textUnder.color = colorTwo;
                    text.color = colorTwo;
                    everythingColor = colorTwo;
                    SaveData();
                    outputText.text = outputText.text + "\n" + "Done, new color: " + color + "\n";
                }
                else outputText.text = outputText.text + "\n" + "Error converting RGB values to numbers" + "\n";
            }
            else outputText.text = outputText.text + "\n" + "Incorrect RGB string format" + "\n";
        }
        else outputText.text = outputText.text + "\n" + "Unknown command, please type help to see commands." + "\n";
        inputField.text = "";
        inputField.ActivateInputField();
        
    }
    
    

}
