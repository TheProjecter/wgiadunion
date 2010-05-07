using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

public partial class pydemo : Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["test"] == null)
        {
            DataTable dt = CommonData.GetBaseTable();
            string path = Server.MapPath("/ThirdPart/test.txt");
            StreamReader sr = File.OpenText(path);
            while (!sr.EndOfStream)
            {
                string[] item = sr.ReadLine().Split('=');
                dt.Rows.Add(item[0], item[1]);
            }
            sr.Close();
            Session["test"] = dt;

        }
        if (Request.QueryString["act"] == "ajaxpy") ajaxpy();
        else if (Request.QueryString["act"] == "getpy")
        {
            Response.ContentType = "txt/html";
            Response.Clear();

            char[] inc = Request.QueryString["v"].ToCharArray();
            string ouc="";
            foreach (char item in inc)
            {
                ouc += char2py.CVT(item.ToString()).ToLower();
            }

            //string a = char2py.CVT();
            Response.Write(ouc);

            //Response.Write(Request.QueryString["v"] + Request.QueryString["t"]);
            Response.End();
        }


        if (!IsPostBack)
        {
            initData();
        }
    }

    private void initData()
    {
        DataTable dt = Session["test"] as DataTable;
        gv.DataSource = dt;
        gv.DataBind();
    }


    protected void py(object sender, EventArgs e)
    {
        DataTable dt = CommonData.GetBaseTable();
        string path = Server.MapPath("/ThirdPart/test.txt");
        StreamReader sr = File.OpenText(path);
        while (!sr.EndOfStream)
        {
            string[] item = sr.ReadLine().Split('=');
            dt.Rows.Add(item[0], item[1]);
        }
        sr.Close();
        Session["test"] = dt;
    }

    //Ajax拼音测试
    private void ajaxpy()
    {
        Response.ContentType = "txt/html";
        Response.Clear();

        string js = "";

        DataTable dt = new DataTable();
        dt = Session["test"] as DataTable;
        string v = Request.QueryString["v"];

        DataRow[] rows = dt.Select("name like '%" + v + "%' or value like '%" + v + "%'");
        if (rows.Length > 0)
        {
            if (rows.Length > 1)
            {
                string r = "";
                foreach (DataRow item in rows)
                {
                    r += item["value"] + ",";
                }
                r = r.TrimEnd(',');
                Response.Write(r);
            }
            else
            {
                Response.Write(rows[0]["value"]);
            }
        }
        else
        {
            Response.Write("");
        }
        Response.End();
    }

}
