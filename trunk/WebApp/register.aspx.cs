using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using LTP.Common;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Master.TabTitle = "信息添加，请详细填写下列信息";
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string username = this.txtusername.Text;

        wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();
        if (bll.GetListByUsername(username).Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('用户名已被使用');", true);
            return;
        }

        #region 服务器验证
        string strErr = "";
        if (this.txtusername.Text == "")
        {
            strErr += "username不能为空！\\n";
        }
        if (this.txtpassword.Text == "")
        {
            strErr += "password不能为空！\\n";
        }
        if (this.txtpassword.Text != this.txtpwd2.Text)
        {
            strErr += "password不能为空！\\n";
        }
        if (this.txtemail.Text == "")
        {
            strErr += "email不能为空！\\n";
        }
        if (this.txtmobile.Text == "" && this.txttel.Text == "")
        {
            strErr += "电话、手机至少选填一项！\\n";
        }
        if (this.txtaccountname.Text == "")
        {
            strErr += "accountname不能为空！\\n";
        }
        if (this.txtaccountno.Text == "")
        {
            strErr += "accountno不能为空！\\n";
        }
        if (this.txtbank.Text == "")
        {
            strErr += "bank不能为空！\\n";
        }
        if (this.txtbranch.Text == "")
        {
            strErr += "branch不能为空！\\n";
        }
        //if (!PageValidate.IsNumber(txtusertype.Text))
        //{
        //    strErr += "usertype不是数字！\\n";
        //}
        if (this.txtcontact.Text == "")
        {
            strErr += "contact不能为空！\\n";
        }
        //if (this.txtqq.Text == "")
        //{
        //    strErr += "qq不能为空！\\n";
        //}
        if (this.txtidcard.Text == "")
        {
            strErr += "idcard不能为空！\\n";
        }
        //if (this.txtaddress.Text == "")
        //{
        //    strErr += "address不能为空！\\n";
        //}
        //if (this.txtzipcode.Text == "")
        //{
        //    strErr += "zipcode不能为空！\\n";
        //}
        //if (!PageValidate.IsNumber(txtstatus.Text))
        //{
        //    strErr += "status不是数字！\\n";
        //}

        if (strErr != "")
        {
            MessageBox.Show(this, strErr);
            return;
        }
        #endregion

        string password = this.txtpassword.Text;
        string email = this.txtemail.Text;
        string mobile = this.txtmobile.Text;
        string accountname = this.txtaccountname.Text;
        string accountno = this.txtaccountno.Text;
        string bank = this.txtbank.Text;
        string branch = this.txtbranch.Text;
        int usertype = 1;//usertype是个人/网站/博客等
        string contact = this.txtcontact.Text;
        string qq = this.txtqq.Text;
        string idcard = this.txtidcard.Text;
        string address = this.txtaddress.Text;
        string zipcode = this.txtzipcode.Text;
        string tel = this.txttel.Text;
        decimal balance = Convert.ToDecimal(0.00);
        DateTime regdate = DateTime.Now;
        string regip = CommonData.GetIp(this.Page);
        //DateTime lastdate = DateTime.Now;
        //string lastip = "";
        int status = 1;//0表示尚未审核通过，暂时默认网站主注册即通过

        wgiAdUnionSystem.Model.wgi_sitehost model = new wgiAdUnionSystem.Model.wgi_sitehost();
        model.username = username;
        model.password = password;
        model.email = email;
        model.mobile = mobile;
        model.accountname = accountname;
        model.accountno = accountno;
        model.bank = bank;
        model.branch = branch;
        model.usertype = usertype;
        model.contact = contact;
        model.qq = qq;
        model.idcard = idcard;
        model.address = address;
        model.zipcode = zipcode;
        model.tel = tel;
        model.balance = balance;
        model.regdate = regdate;
        model.regip = regip;
        //model.lastdate = lastdate;
        //model.lastip = lastip;
        model.status = status;

        try
        {
            bll.Add(model);

            Response.Redirect("regSuccess.aspx");
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('内部错误');", true);
        }

    }

}
