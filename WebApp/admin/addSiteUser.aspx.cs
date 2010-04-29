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

public partial class admin_addSiteUser : ValidatePage
{
    private string uid="";

    protected void Page_Load(object sender, EventArgs e)
    {
        Control title = Page.LoadControl("pageControl/title.ascx");
        title.ID = "uc_title";
        this.holderheader.Controls.Add(title);
        if (!IsPostBack)
        {
            string act = Request.QueryString["act"];
            switch (act)
            { 
                case "add":
                    caseAdd();
                    break;
                case "edit":
                    caseEdit("edit");
                    break;
                default:
                    caseEdit("show");
                    break;

            }
        }
    }

    private void caseAdd()
    {
        btnsubmit.CommandArgument = "add";
        //新增时，状态信息，网站信息均无需填入
        this.fdst_status.Visible = false;
        this.fdst_site.Visible = false;
    
    }

    /// <summary>
    /// 编辑/查看时绑定数据
    /// </summary>
    /// <param name="action">编辑传入edit，查看传入show</param>
    private void caseEdit(string action)
    {
        uid = Request.QueryString["uid"];
        if (uid == "")
        {
            Response.Write("非法进入");
            Response.End();
        }

        //绑定数据

        wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();
        wgiAdUnionSystem.Model.wgi_sitehost model = bll.GetModel(int.Parse(uid));
        
        
        this.txtusername.Text = model.username;
        this.txtpassword.Attributes.Add("value",model.password);
        this.txtpwd2.Attributes.Add("value", model.password);
        this.txtemail.Text = model.email;
        this.txtmobile.Text = model.mobile;

        this.txtaccountname.Text = model.accountname;
        this.txtaccountno.Text = model.accountno;
        this.txtbank.Text = model.bank;
        this.txtbranch.Text = model.branch;

        //this.txtusertype.Text = model.usertype.ToString(); 

        this.txtcontact.Text = model.contact;
        this.txtqq.Text = model.qq;
        this.txtidcard.Text = model.idcard;
        this.txtaddress.Text = model.address;
        this.txtzipcode.Text = model.zipcode;
        this.txttel.Text = model.tel;

        //以下为只显示，不编辑，不新增的字段
        this.hiduid.Value = model.userid.ToString();
        this.txtbalance.Text = model.balance.ToString()+"&nbsp;元";
        this.txtregdate.Text = model.regdate.ToString();
        this.txtregip.Text = model.regip;
        this.txtlastdate.Text = model.lastdate.ToString();
        this.txtlastip.Text = model.lastip;
        this.txtstatus.Text = CommonData.getAccountStatusByValue(model.status.ToString());
        
        //网站信息

        if (action == "edit")
        {
            lblusername.Text = model.username;
            lblusername.Visible = true;
            txtusername.Visible = false;
            fdst_bank.Visible = false;//不允许编辑用户银行账户资料
            btnsubmit.CommandArgument = "edit";
            btncancel.Visible = false;//编辑状态下尽量不给“重置”的功能，以免误清空原用户数据
        }
        else if (action == "show")
        { 
            btnsubmit.Visible = false;
            btncancel.Visible = false;
            fdst_site.Visible = true;//只有查看状态下才有必要看网站信息
            trpwd1.Visible = false;//密码不允许查看，但有权更改
            trpwd2.Visible = false;

            odsData.SelectParameters["userid"].DefaultValue = uid;
            lvsite.DataSourceID = "odsData";
            lvsite.DataBind();

            foreach (Control item in this.form.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Enabled = false;
                }
                else if (item.Controls.Count>0)
                {
                    foreach (Control v in item.Controls)
                    {
                        if (v is TextBox)
                        {
                            (v as TextBox).Enabled = false;
                        }

                    }
                }
            }
            txtusername.Enabled = false;
            
        }
    
    }


    protected void dosubmit(object sender, CommandEventArgs e)
    {
        wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();

        string username = "";

        if (e.CommandArgument.ToString() == "add")
        {
            username = this.txtusername.Text;
            if (bll.GetListByUsername(username).Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('用户名已被使用');", true);
                return;
            }
        }

        string password = this.txtpassword.Text;
        string email = this.txtemail.Text;
        string mobile = this.txtmobile.Text;
        string accountname = this.txtaccountname.Text;
        string accountno = this.txtaccountno.Text;
        string bank = this.txtbank.Text;
        string branch = this.txtbranch.Text;
        int usertype = 1;//usertype是个人/网站/博客等，因为已经在usersite里面可以多重定义，所以改为用户在系统里的类型，如网站主，广告主
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


        if (e.CommandArgument.ToString() == "add")
        {
            wgiAdUnionSystem.Model.wgi_sitehost model = new wgiAdUnionSystem.Model.wgi_sitehost();
            model.username = username;
            model.password = password;
            model.email = email;
            model.mobile = mobile;
            model.contact = contact;
            model.qq = qq;
            model.idcard = idcard;
            model.address = address;
            model.zipcode = zipcode;
            model.tel = tel;

            //银行账户信息允许管理员添加，却不允许管理员更改
            model.accountname = accountname;
            model.accountno = accountno;
            model.bank = bank;
            model.branch = branch;

            //账号状态信息自动读取，不允许编辑
            //model.balance = balance;
            //model.lastdate = lastdate;
            //model.lastip = lastip;
            model.regdate = regdate;
            model.regip = regip;
            model.usertype = usertype;
            model.status = status;

            try
            {
                bll.Add(model);

                ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('添加成功');top.location=top.location;", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('内部错误');", true);
            }
        }
        else if (e.CommandArgument.ToString() == "edit")
        {
            try
            {
                int userid = int.Parse(this.hiduid.Value);

                wgiAdUnionSystem.Model.wgi_sitehost model = bll.GetModel(userid);

                model.password = password;
                model.email = email;
                model.mobile = mobile;
                model.contact = contact;
                model.qq = qq;
                model.idcard = idcard;
                model.address = address;
                model.zipcode = zipcode;
                model.tel = tel;

                bll.Update(model);

                ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('修改成功');top.location=top.location;", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('内部错误');", true);
            }
                
        }
    }

}
