using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextManager : MonoBehaviour
{
    public class TextTemplete
    {
        public int _num;
        public string _hash;
        public string _text;
    };

    private List<TextTemplete> _textTempletesList;

    public void Initialize()
    {
        _textTempletesList = new List<TextTemplete>();
        LoadText("");
    }

    private void LoadText(string textName)
    {
        TextAsset textasset = new TextAsset(); 
        textasset = Resources.Load("test", typeof(TextAsset)) as TextAsset; 
        var textMessage = textasset.text.Split('\n'); 
        var columnLength = textMessage[0].Split(new[] { "   " }, StringSplitOptions.None).Length;
        var rowLength = textMessage.Length;

        var textWords = new string[rowLength, columnLength];
        for (int i = 0; i < rowLength; i++)
        {
            var tempWords = textMessage[i].Split(new[] { "   " }, StringSplitOptions.None);
            if (i == 0) continue; 

            TextTemplete templete = new TextTemplete();
            templete._num = Int32.Parse(tempWords[0]);
            templete._hash = tempWords[1];
            templete._text = tempWords[2];
            _textTempletesList.Add(templete);
        }
    }

    public void Test()
    {
        int a = 0;
    }

}
