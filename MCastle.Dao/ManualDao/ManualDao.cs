using MCastle.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCastle.Dao
{
    public class ManualDao:IManualDao
    {
        public string ReturnString(string text)
        {
            return text + ":This is Type1";
        }
    }
}
