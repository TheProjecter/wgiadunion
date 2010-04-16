using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class advertiser_standard_add : advertiserPage
{
    wgiAdUnionSystem.BLL.wgi_discount bdis = new wgiAdUnionSystem.BLL.wgi_discount();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!string.IsNullOrEmpty(Request["id"]))
        {
           wgiAdUnionSystem.Model.wgi_discount mdis= bdis.GetModel(Helper.HelperDigit.ConvertToInt32(Request["id"]));
           txtpay.Text = mdis.payamt;
           txtconf.Text = mdis.payintro;
           txtbegin.Text = mdis.endtime.Value.ToString("yyyy-MM-dd");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       
        wgiAdUnionSystem.Model.wgi_discount mdis = new wgiAdUnionSystem.Model.wgi_discount();
        mdis.companyid = base.companyid;
        mdis.payamt = txtpay.Text;
        mdis.payintro = txtconf.Text;
        mdis.endtime = Helper.HelperDateTime.InputDateTime(txtbegin.Text);
        mdis.addtime = DateTime.Now;

        if (bdis.Add(mdis) > 0)
        {
            Response.Redirect("standard_list.aspx");
        }
    }
}
