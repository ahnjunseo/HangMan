using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json.Linq;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public bool hasWords = false;
    public List<(string word, string category)> words = new();
    public int wordIndex = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);

        if (!hasWords)
        {
            //take words
            //words = new List<(string word, string category)>() { ("IVORY", "»ö±ò"), ("MAGENTA", "»ö±ò"), ("EARTH","µÕ±Ù ¹°Ã¼") };
            ReadTxt(Application.dataPath+"/data.txt");

            void ReadTxt(string filePath)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Exists)
                {
                    StreamReader reader = new StreamReader(filePath);
                    while (!reader.EndOfStream)
                    {
                        words.Add((reader.ReadLine().Trim(), reader.ReadLine().Trim()));
                    }
                    reader.Close();
                }
                else
                {
                    words.Add(("ERROR", "¿À·ù"));
                }
            }
            hasWords = true;
        }
    }
}
