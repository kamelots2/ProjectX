using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : Singleton<LanguageManager>
{
    Dictionary<string, string> dLanguage = new Dictionary<string, string>();

    public void InitLanguage()
    {
        LoadDataManager.XLSX("Language.xlsx", dLanguage);
    }

    public string GetString(string str)
    {
        string value;
        dLanguage.TryGetValue(str, out value);
        return value;
    }
}