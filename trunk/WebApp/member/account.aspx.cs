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

public partial class member_account : System.Web.UI.Page
{
    private int userid;

    protected void Page_Load(object sender, EventArgs e)
    {
        validateMember userobj = MasterPageOpration.getMasterControl(this.Page.Master, "Muser");
        if (userobj.suser.userid != 0)
        {
            userid = userobj.suser.userid;
            if (!IsPostBack) ShowInfo(userid);
        }
        else
        {
            if (IsPostBack)
                ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('您已登出系统，请重新登录');location.href='/member/Default.aspx?url='"+Request.CurrentExecutionFilePath+";", true);
        }
    }

    private void ShowInfo(int userid)
    {
        wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();
        wgiAdUnionSystem.Model.wgi_sitehost model = bll.GetModel(userid);
        this.txtemail.Text = model.email;
        this.txtmobile.Text = model.mobile;
        this.txtcontact.Text = model.contact;
        this.txtqq.Text = model.qq;
        this.txtidcard.Text = model.idcard;
        this.txtaddress.Text = model.address;
        this.txtzipcode.Text = model.zipcode;
        this.txttel.Text = model.tel;
        this.txtregdate.Text = model.regdate.ToString();
        this.txtregip.Text = model.regip;
        this.txtlastdate.Text = model.lastdate.ToString();
        this.txtlastip.Text = model.lastip;
        this.txtstatus.Text = CommonData.getAccountStatusByValue(model.status.ToString());

    }

    public void btnUpdate_Click(object sender, EventArgs e)
    {

        string strErr = "";
        if (this.txtemail.Text == "")
        {
            strErr += "email不能为空！\\n";
        }
        if (this.txtmobile.Text == "")
        {
            strErr += "mobile不能为空！\\n";
        }
        if (this.txtcontact.Text == "")
        {
            strErr += "contact不能为空！\\n";
        }
        if (this.txtqq.Text == "")
        {
            strErr += "qq不能为空！\\n";
        }
        if (this.txtidcard.Text == "")
        {
            strErr += "idcard不能为空！\\n";
        }
        if (this.txtaddress.Text == "")
        {
            strErr += "address不能为空！\\n";
        }
        if (this.txtzipcode.Text == "")
        {
            strErr += "zipcode不能为空！\\n";
        }
        if (this.txttel.Text == "")
        {
            strErr += "tel不能为空！\\n";
        }

        if (strErr != "")
        {
            MessageBox.Show(this, strErr);
            return;
        }
        
        string email = this.txtemail.Text;
        string mobile = this.txtmobile.Text;
        string contact = this.txtcontact.Text;
        string qq = this.txtqq.Text;
        string idcard = this.txtidcard.Text;
        string address = this.txtaddress.Text;
        string zipcode = this.txtzipcode.Text;
        string tel = this.txttel.Text;

        wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();

        wgiAdUnionSystem.Model.wgi_sitehost model = bll.GetModel(userid);
        model.email = email;
        model.mobile = mobile;
        model.contact = contact;
        model.qq = qq;
        model.idcard = idcard;
        model.address = address;
        model.zipcode = zipcode;
        model.tel = tel;

        ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('资料修改成功');", true);
        bll.Update(model);

    }
}
