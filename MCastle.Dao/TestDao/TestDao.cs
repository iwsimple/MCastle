using MCastle.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCastle.Dao
{
    public class TestDao : ITestDao
    {

        public string ReturnOk(string text)
        {
            return text + " Ok!";
        }
    }
}
