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
        if (!Page.IsPostBack)
        {
            validateMember userobj = MasterPageOpration.getMasterControl(this.Page.Master, "Muser");
			if(userobj.suser.userid!=0) {userid=userobj.suser.userid;ShowInfo(userid);}
			else Response.Redirect("/member/Default.aspx?url="+ Request.CurrentExecutionFilePath);
        }
    }

    private void ShowInfo(int userid)
    {
        wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();
        wgiAdUnionSystem.Model.wgi_sitehost model = bll.GetModel(userid);
        this.lbluserid.Text = model.userid.ToString();
        this.txtusername.Text = model.username;
        this.txtpassword.Text = model.password;
        this.txtemail.Text = model.email;
        this.txtmobile.Text = model.mobile;
        this.txtaccountname.Text = model.accountname;
        this.txtaccountno.Text = model.accountno;
        this.txtbank.Text = model.bank;
        this.txtbranch.Text = model.branch;
        this.txtusertype.Text = model.usertype.ToString();
        this.txtcontact.Text = model.contact;
        this.txtqq.Text = model.qq;
        this.txtidcard.Text = model.idcard;
        this.txtaddress.Text = model.address;
        this.txtzipcode.Text = model.zipcode;
        this.txttel.Text = model.tel;
        this.txtbalance.Text = model.balance.ToString();
        this.txtregdate.Text = model.regdate.ToString();
        this.txtregip.Text = model.regip;
        this.txtlastdate.Text = model.lastdate.ToString();
        this.txtlastip.Text = model.lastip;
        this.txtstatus.Text = model.status.ToString();

    }

    public void btnUpdate_Click(object sender, EventArgs e)
    {

        string strErr = "";
        if (this.txtusername.Text == "")
        {
            strErr += "username不能为空！\\n";
        }
        if (this.txtpassword.Text == "")
        {
            strErr += "password不能为空！\\n";
        }
        if (this.txtemail.Text == "")
        {
            strErr += "email不能为空！\\n";
        }
        if (this.txtmobile.Text == "")
        {
            strErr += "mobile不能为空！\\n";
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
        if (!PageValidate.IsNumber(txtusertype.Text))
        {
            strErr += "usertype不是数字！\\n";
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
        if (!PageValidate.IsDecimal(txtbalance.Text))
        {
            strErr += "balance不是数字！\\n";
        }
        if (!PageValidate.IsDateTime(txtregdate.Text))
        {
            strErr += "regdate不是时间格式！\\n";
        }
        if (this.txtregip.Text == "")
        {
            strErr += "regip不能为空！\\n";
        }
        if (!PageValidate.IsDateTime(txtlastdate.Text))
        {
            strErr += "lastdate不是时间格式！\\n";
        }
        if (this.txtlastip.Text == "")
        {
            strErr += "lastip不能为空！\\n";
        }
        if (!PageValidate.IsNumber(txtstatus.Text))
        {
            strErr += "status不是数字！\\n";
        }

        if (strErr != "")
        {
            MessageBox.Show(this, strErr);
            return;
        }
        string username = this.txtusername.Text;
        string password = this.txtpassword.Text;
        string email = this.txtemail.Text;
        string mobile = this.txtmobile.Text;
        string accountname = this.txtaccountname.Text;
        string accountno = this.txtaccountno.Text;
        string bank = this.txtbank.Text;
        string branch = this.txtbranch.Text;
        int usertype = int.Parse(this.txtusertype.Text);
        string contact = this.txtcontact.Text;
        string qq = this.txtqq.Text;
        string idcard = this.txtidcard.Text;
        string address = this.txtaddress.Text;
        string zipcode = this.txtzipcode.Text;
        string tel = this.txttel.Text;
        decimal balance = decimal.Parse(this.txtbalance.Text);
        DateTime regdate = DateTime.Parse(this.txtregdate.Text);
        string regip = this.txtregip.Text;
        DateTime lastdate = DateTime.Parse(this.txtlastdate.Text);
        string lastip = this.txtlastip.Text;
        int status = int.Parse(this.txtstatus.Text);


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
        model.lastdate = lastdate;
        model.lastip = lastip;
        model.status = status;

        model.userid = Convert.ToInt32(lbluserid.Text);

        wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();
        bll.Update(model);

    }
}
