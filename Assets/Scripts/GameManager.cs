using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private TextMeshProUGUI help;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI decor;
    private Color _color;
    void Start()
    {
        if (TextBox.everythingColor == Color.clear)// вибачте за говнокод(
        {
            TextBox.everythingColor = Color.white;
            
        }
        else if (TextBox.everythingColor == Color.black)// вибачте за говнокод(
        {
            TextBox.everythingColor = Color.white;  
        }
        
        _color = TextBox.everythingColor;
        _material.color = _color;
        help.color = _color;
        score.color = _color;
        decor.color = _color;
    }
    
}
