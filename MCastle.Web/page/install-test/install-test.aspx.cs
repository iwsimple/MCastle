using MCastle.Dao;
using MCastle.Domain;
using MCastle.IDao;
using MCastle.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        //string text = "Castle";
        //lbl.Text = IocContainer.Get<Manual2Dao>().ReturnString(text);
        //IocContainer ioc = new IocContainer();

        //Thread thread = new Thread(new ThreadStart(output));
        //lbl.Text = IocContainer.Get<IManualDao>().get();

        Astick[] array = new Astick[] { new Astick("草莓"), new Astick("抹茶"), new Astick("巧克力") };
        AstickCollection collection = new AstickCollection(array);
        string text = "";
        foreach (Astick astick in collection)
        {
            text = text + astick.Name;
        }
        lbl.Text = text;
    }

    public void output()
    {

    }
}