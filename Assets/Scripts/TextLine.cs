using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextLine : MonoBehaviour
{
    public TextMeshProUGUI[] textLine;

    private string saveText;
    public int max = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PageBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Page_1()
    {
        for (int i = 1; i <= max; i++)
        {
            for (int ii = 1; ii <= 13; ii++)
            {
                string path = Application.dataPath + $"/Texts/Page_{i}/page_{i}_{ii}.txt";

                if (File.Exists(path))
                {
                    saveText = File.ReadAllText(path);

                    Debug.Log($"복사가 잘 되는가{ii}");
                    textLine[ii - 1].text = saveText;
                    
                }
                else
                {
                    Debug.LogWarning($"page_{i}_{ii}.txt 파일이 존재하지 않습니다.");

                    textLine[ii - 1].text = (saveText = null);

                }

                yield return new WaitForSeconds(1.0f);
            }
        }        
    }

    public void PageBoard()
    {
        StartCoroutine(Page_1());
    }
}
