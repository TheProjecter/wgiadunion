using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

/// <summary>
///char2py 的摘要说明
/// </summary>

public class char2py
{

    ///**  国标码和区位码转换常量      */
    //public static int GB_SP_DIFF = 160;

    ///**  存放国标一级汉字不同读音的起始区位码       */
    //public static int[] secPosvalueList = { 1601, 1637, 1833, 2078, 2274, 2302, 2433, 2594, 2787, 3106, 3212, 3472,
    //  3635, 3722, 3730, 3858, 4027, 4086, 4390, 4558, 4684, 4925, 5249, 5600 };

    ///**  存放国标一级汉字不同读音的起始区位码对应读音       */
    //public static char[] firstLetter = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
    //  'q', 'r', 's', 't', 'w', 'x', 'y', 'z' };


    /// <summary>
    /// 获取字符串的拼音首字母 
    /// </summary>
    /// <param name="oriStr">字符串</param>
    /// <returns>拼音首字母</returns>    
    //public static String getFirstLetter(String oriStr)
    //{
    //    String str = oriStr.ToLower();
    //    StringBuilder buffer = new StringBuilder();
    //    char ch;
    //    char[] temp;
    //    for (int i = 0; i < str.Length; i++)
    //    { //依次处理str中每个字符   
    //        ch = str[i];
    //        temp = new char[] { ch };
    //        byte[] uniCode = UTF8Encoding.UTF8.GetBytes(temp); //new String(temp).getBytes();
    //        if (uniCode[0] < 128 && uniCode[0] > 0)
    //        { //   非汉字   
    //            buffer.Append(temp);
    //        }
    //        else
    //        {
    //            buffer.Append(convert(uniCode));
    //        }
    //    }
    //    return buffer.toString();
    //}

    public static string CVT(string str)
    {
        if (str.CompareTo("吖") < 0)
        {
            string s = str.Substring(0, 1).ToUpper();
            if (char.IsNumber(s, 0))
            {
                return "0";
            }
            else
            {
                return s;
            }

        }
        else if (str.CompareTo("八") < 0)
        {
            return "A";
        }
        else if (str.CompareTo("嚓") < 0)
        {
            return "B";
        }
        else if (str.CompareTo("咑") < 0)
        {
            return "C";
        }
        else if (str.CompareTo("妸") < 0)
        {
            return "D";
        }
        else if (str.CompareTo("发") < 0)
        {
            return "E";
        }
        else if (str.CompareTo("旮") < 0)
        {
            return "F";
        }
        else if (str.CompareTo("铪") < 0)
        {
            return "G";
        }
        else if (str.CompareTo("讥") < 0)
        {
            return "H";
        }
        else if (str.CompareTo("咔") < 0)
        {
            return "J";
        }
        else if (str.CompareTo("垃") < 0)
        {
            return "K";
        }
        else if (str.CompareTo("嘸") < 0)
        {
            return "L";
        }
        else if (str.CompareTo("拏") < 0)
        {
            return "M";
        }
        else if (str.CompareTo("噢") < 0)
        {
            return "N";
        }
        else if (str.CompareTo("妑") < 0)
        {
            return "O";
        }
        else if (str.CompareTo("七") < 0)
        {
            return "P";
        }
        else if (str.CompareTo("亽") < 0)
        {
            return "Q";
        }
        else if (str.CompareTo("仨") < 0)
        {
            return "R";
        }
        else if (str.CompareTo("他") < 0)
        {
            return "S";
        }
        else if (str.CompareTo("哇") < 0)
        {
            return "T";
        }
        else if (str.CompareTo("夕") < 0)
        {
            return "W";
        }
        else if (str.CompareTo("丫") < 0)
        {
            return "X";
        }
        else if (str.CompareTo("帀") < 0)
        {
            return "Y";
        }
        else if (str.CompareTo("咗") < 0)
        {
            return "Z";
        }
        else
        {
            return "0";
        }


    }

}
