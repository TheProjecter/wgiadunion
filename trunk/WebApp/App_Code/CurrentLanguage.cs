using System;
using System.Collections;

/// <summary>
/// CurrentLanguage 的摘要说明
/// </summary>
[Serializable]
public class CurrentLanguage
{
    private string currlanguage;

    private string currtheme;

    public string Currtheme
    {
        get { return currtheme; }
        set { currtheme = value; }
    }

    public string Currlanguage
    {
        get { return currlanguage; }
        set { currlanguage = value; }
    }

	public CurrentLanguage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    //public static string GetCurrTheme(string curlang)
    //{
    //    string curtheme = string.Empty;

    //    switch (curlang)
    //    {
    //        case:"zh-cn"
    //            curtheme=
    //            break;
    //        case:""
    //            break;
    //        case:""
    //            break;
    //         default
                
    //    }
    //}
}
