using System.Web;

/// <summary>
/// SystemParameter 的摘要说明
/// </summary>
public class SystemParameter
{
    public SystemParameter()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static readonly string APP_PATH = HttpContext.Current.Request.ApplicationPath;
    public static readonly string APP_HTTP_PATH = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath;

}
