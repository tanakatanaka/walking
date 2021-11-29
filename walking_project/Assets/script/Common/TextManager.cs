using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextManager : MonoBehaviour
{
    public string[] textMessage; //�e�L�X�g�̉��H�O�̈�s������ϐ�
    public string[,] textWords; 

    private int rowLength; //�e�L�X�g���̍s�����擾����ϐ�
    private int columnLength; //�e�L�X�g���̗񐔂��擾����ϐ�

    public void Start()
    {
        LoadText("");
    }


    public void LoadText(string textName)
    {
        TextAsset textasset = new TextAsset(); 
        textasset = Resources.Load("test", typeof(TextAsset)) as TextAsset; 
        string TextLines = textasset.text; 

        //Split�ň�s�Â�������1���z����쐬
        textMessage = TextLines.Split('\n'); //

        //�s���Ɨ񐔂��擾
        columnLength = textMessage[0].Split('\t').Length;
        rowLength = textMessage.Length;

        //2���z����`
        textWords = new string[rowLength, columnLength];

        for (int i = 0; i < rowLength; i++)
        {

            string[] tempWords = textMessage[i].Split('\t'); //textMessage���J���}���Ƃɕ��������̂��ꎞ�I��tempWords�ɑ��

            for (int n = 0; n < columnLength; n++)
            {
                textWords[i, n] = tempWords[n]; 
            }
        }
    }

}
