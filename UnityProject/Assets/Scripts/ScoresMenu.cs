using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ScoresMenu : MonoBehaviour
{
    public TextMeshProUGUI[] scoresTexts;

    private StreamReader sr;
    private List<KeyValuePair<string, int>> recordsList;

    public void ReadRecords()
    {
        sr = null;
        recordsList = new List<KeyValuePair<string, int>>();

        string recordsFile = Application.persistentDataPath + "/records.txt";
        try
        {
            using (sr = new StreamReader(recordsFile))
            {
                while (sr.Peek() >= 0)
                {
                    string readName = sr.ReadLine();
                    string record = sr.ReadLine();
                    recordsList.Add(new KeyValuePair<string, int>(readName, Convert.ToInt32(record)));
                }
                recordsList.Sort(SortRecords);
            }
        }
        catch (Exception)
        {
            Debug.Log("Error");
        }

        ShowRecords();
    }

    public void ShowRecords()
    {
        if (recordsList.Count == 0)
        {
            scoresTexts[0].text = "No records yet";
        }
        else
        {
            int max;
            if (recordsList.Count > 6)
            {
                max = 6;
            }
            else
            {
                max = recordsList.Count;
            }

            for (int i = 0; i < max; i++)
            {
                scoresTexts[i].text = recordsList[i].Key + " -> " + recordsList[i].Value;
            }
        }
    }

    private int SortRecords(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
    {
        return b.Value.CompareTo(a.Value);
    }
}
