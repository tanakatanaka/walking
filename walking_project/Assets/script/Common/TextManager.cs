using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextManager : MonoBehaviour
{
    public string[] textMessage; //テキストの加工前の一行を入れる変数
    public string[,] textWords; 

    private int rowLength; //テキスト内の行数を取得する変数
    private int columnLength; //テキスト内の列数を取得する変数

    public void Start()
    {
        LoadText("");
    }


    public void LoadText(string textName)
    {
        TextAsset textasset = new TextAsset(); 
        textasset = Resources.Load("test", typeof(TextAsset)) as TextAsset; 
        string TextLines = textasset.text; 

        //Splitで一行づつを代入した1次配列を作成
        textMessage = TextLines.Split('\n'); //

        //行数と列数を取得
        columnLength = textMessage[0].Split('\t').Length;
        rowLength = textMessage.Length;

        //2次配列を定義
        textWords = new string[rowLength, columnLength];

        for (int i = 0; i < rowLength; i++)
        {

            string[] tempWords = textMessage[i].Split('\t'); //textMessageをカンマごとに分けたものを一時的にtempWordsに代入

            for (int n = 0; n < columnLength; n++)
            {
                textWords[i, n] = tempWords[n]; 
            }
        }
    }

}
