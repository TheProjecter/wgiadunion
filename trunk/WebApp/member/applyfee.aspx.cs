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

public partial class member_applyfee : System.Web.UI.Page
{
    private int userid;

    protected void Page_Load(object sender, EventArgs e)
    {
        validateMember userobj = MasterPageOpration.getMasterControl(this.Page.Master, "Muser");
        if (userobj.suser.userid != 0)
        {
            userid = userobj.suser.userid;
            if (!IsPostBack) initData();
        }
        else
        {
            if (IsPostBack)
                ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('您已登出系统，请重新登录');location.href='/member/Default.aspx?url='" + Request.CurrentExecutionFilePath + ";", true);
        }
    }

    private void initData()
    {
        validateMember userobj = MasterPageOpration.getMasterControl(this.Page.Master, "Muser");

        wgiAdUnionSystem.BLL.wgi_cash bll_cash = new wgiAdUnionSystem.BLL.wgi_cash();

        DataTable dt = bll_cash.GetList(" a.userid="+userid+" and b.status<>4 and b.status<>5").Tables[0];
        int applycount = dt.Rows.Count;

        if (applycount > 1)//多条未处理纪录，说明数据库有误，禁止继续操作
        {
            Response.Write("您的申请纪录异常，暂时屏蔽您申请佣金的权限，请联系<a href='mailto:walker@wingoi.com'>管理员</a>解决后再来申请佣金！");
            Response.End();
            return;
        }

        this.lblmoney.Text = new wgiAdUnionSystem.BLL.wgi_sitehost().GetModel(userid).balance.ToString();

        

        if (Convert.ToDecimal(lblmoney.Text) < 100)
        { 
            //从未申请过，或所有申请已处理
            if (applycount == 0)
            {
                lblapply.Text = "<b>您的申请状态：</b>您的佣金不到100元，不可以申请";
                lblapply.Visible = true;
                hidstep.Value = "-1";
            }
            else//有申请正在处理流程中
            {
                hidstep.Value = dt.Rows[0]["status"].ToString();
                lblapply.Text = "<b>您的申请状态：</b>" + CommonData.getApplyStatusByValue(hidstep.Value);
                lblapply.Visible = true;
            }
        }
        else
        {
            if (applycount == 0)
            { 
                hidstep.Value = "0";
                btnapply.Visible = true;
                txtapplyremark.Visible = true;
                txtapplyamount.Text = this.lblmoney.Text;
                txtapplyamount.Visible = true;
                txtapplyamount.ReadOnly = true;
                lblfixtxt.Visible = true;
            }
            else//有申请未处理，不允许再次申请
            {
                hidstep.Value = dt.Rows[0]["status"].ToString();
                lblapply.Text = "<b>您的申请状态：</b>" + CommonData.getApplyStatusByValue(hidstep.Value) + "&nbsp;请等待此次申请处理后再申请佣金";
                lblapply.Visible = true;
            }
        }
    }

    protected void applyclick(object sender, EventArgs e)
    {
        decimal amount = 0.00M;
        try
        {
            amount = Convert.ToDecimal(txtapplyamount.Text);
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('请输入合理的数字金额');", true);
            return;
        }
        if (amount < 100)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('最少提取100元');", true);
            return;
        }

        wgiAdUnionSystem.Model.wgi_cash model = new wgiAdUnionSystem.Model.wgi_cash();
        model.status = 1;
        model.applydate = DateTime.Now;
        model.cash = amount;
        model.memo_user = txtapplyremark.Text;
        model.userid = userid;

        new wgiAdUnionSystem.BLL.wgi_cash().Add(model);

        //成功递交申请后，可支付佣金送去相应数目
        wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();
        wgiAdUnionSystem.Model.wgi_sitehost model2 = bll.GetModel(userid);
        model2.balance -= amount;
        bll.Update(model2);



        //Response.Redirect("applyfee.aspx");
        Response.Write(Helper.HelperString.getAlertJumpString("申请成功", "applyfee.aspx"));
    }

}
