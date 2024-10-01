using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavefileManager : MonoBehaviour
{
    public string nameToLoad;
    public DNDChar character;

    public void SaveCharacter()
    {
        string filepath = Application.dataPath + "/" + character.GetName() + ".json";

        using (StreamWriter sw = new(filepath))
        {
            sw.Write(JsonUtility.ToJson(character.Save()));
            Debug.Log(string.Format("Saved character at {0}", filepath));
        }
    }

    public void LoadCharacter()
    {
        string filepath = Application.dataPath + "/" + nameToLoad + ".json";

        if(!File.Exists(filepath))
        {
            Debug.LogWarning(string.Format("Tried to read from nonexistent file {0}", filepath));
            return;
        }

        using (StreamReader sr = new(filepath))
        {
            var data = JsonUtility.FromJson<SaveableCharData<DNDChar.Stats>>(sr.ReadToEnd());
            character.Load(data);
            Debug.Log(string.Format("Loaded character from {0}", filepath));
        }
    }
}
