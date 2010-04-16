using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace HOH
{
    /**//// <summary>
    /// CheckCode 的摘要说明。
    /// </summary>
    public partial class  CheckCode : System.Web.UI.Page
    {

        #region 验证码长度(默认4个验证码的长度)#region 验证码长度(默认4个验证码的长度)
        int length = 4;
        #endregion

        #region 验证码字体大小(默认12像素)#region 验证码字体大小(默认12像素)
        int fontSize = 12;
        #endregion

        #region 边框补(默认2像素)#region 边框补(默认2像素)
        int padding = 1;
        #endregion

        #region 是否输出燥点(默认不输出)#region 是否输出燥点(默认不输出)
        bool chaos = true;
        #endregion

        #region 输出燥点的颜色(默认灰色)#region 输出燥点的颜色(默认灰色)
        Color chaosColor = System.Drawing.Color.Pink;
        #endregion

        #region 自定义背景色(默认白色)#region 自定义背景色(默认白色)
        Color backgroundColor = Color.White;
        #endregion

        #region 自定义随机颜色数组#region 自定义随机颜色数组
        Color[] colors = {Color.Black,Color.Red,Color.DarkBlue,Color.Green,Color.Orange,Color.Brown,Color.DarkCyan,Color.Purple};
        #endregion

        #region 自定义字体数组#region 自定义字体数组
        string[] fonts = {"Arial", "Georgia"};
        #endregion

        #region 自定义随机码字符串序列(使用逗号分隔)#region 自定义随机码字符串序列(使用逗号分隔)
        string codeSerial = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
        #endregion

        private void Page_Load(object sender, System.EventArgs e)
        {
            HOH.VerifyCode v = new HOH.VerifyCode();
   
            v.Length = this.length;
   
            v.FontSize = this.fontSize;
   
            v.Chaos = this.chaos;
   
            v.BackgroundColor = this.backgroundColor;
   
            v.ChaosColor = this.chaosColor;

            v.CodeSerial = this.codeSerial;

            v.Colors = this.colors;

            v.Fonts = this.fonts;

            v.Padding = this.padding;

            string code = v.CreateVerifyCode();    //取随机码

            v.CreateImageOnPage(code, this.Context);  // 输出图片
 
            Session["CheckCode"] = code.ToLower();   // 使用Session["CheckCode"]取验证码的值
   
        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }
        #endregion

        #region Web 窗体设计器生成的代码  
        /**//// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {    
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
    }
}
