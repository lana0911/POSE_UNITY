using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class stream_Read3 : MonoBehaviour
{
    //�Ψ���ܦr����TextUi
    public Text Titles;
    //�ɮ׬y,�Τ_Ū���奻
    StreamReader sr;
    //�奻�����r�������
    int lineCount = 0;
    bool start_n = true;


    void Start()
    {

    }



    void Update()
    {
        if (start_n == true)
        {
            if (Gobal_TCP.pss_name == 0)
            {
                StartCoroutine(Display());

                start_n = false;
            }


        }

    }

    IEnumerator Display()
    {
        sr = new StreamReader(Application.dataPath + "/text2.txt");
        //�إߤ@�Ӭy�A�Τ_Ū�����
        StreamReader srLine = new StreamReader(Application.dataPath + "/text2.txt");
        //�`����Ū����ơA���쬰null����
        while (srLine.ReadLine() != null)
        {
            lineCount++;
        }
        //����������y
        srLine.Close();
        srLine.Dispose();
        //Game name show over
        for (int i = 0; i < lineCount; i++)
        {
            string tempText = sr.ReadLine();
            Titles.text = tempText.Split('$')[0];
            Debug.Log(Titles.text);
            //�]�N�O
            float tempTime;
            //�N�夤������$3����3Ū���X��
            if (float.TryParse(tempText.Split('$')[1], out tempTime))
            {
                //��{����
                yield return new WaitForSeconds(tempTime);
            }


        }


        //����������y
        sr.Close();
        sr.Dispose();
    }
}