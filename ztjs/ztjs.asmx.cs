using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SufeiUtil;
using Newtonsoft.Json;

namespace ztjs
{
    /// <summary>
    /// ztjs 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class ztjs : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string getProject()
        {
            string strSql = "select DeptName  from  T_E_Org_Department where TypeID='FGS'";
            try
            {
                DataTableCollection tablecollection = SqlHelper.GetTableText(strSql,null);
                DataTable table = tablecollection[0];
                string json = JsonConvert.SerializeObject(table);
                return json;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
