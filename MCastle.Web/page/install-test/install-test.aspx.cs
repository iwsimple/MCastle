using MCastle.Dao;
using MCastle.IDao;
using MCastle.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class page_install_test_install_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Click(object sender, EventArgs e)
    {
        string text = "Castle";
        lbl.Text = IocContainer.Get<Manual2Dao>().ReturnString(text);
    }
}