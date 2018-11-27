using MCastle.IDao;

namespace MCastle.Dao
{
    public class ManualDao : extendDao, IManualDao
    {
        public string a;

        public ManualDao(extendDao ex)
        {
            a = ex.p;
        }

        public string ReturnString(string text)
        {
            return text + ":This is Type1";
        }

        public new void Test()
        {

        }

        public string get()
        {
            extendDao ex = new extendDao();
            ex.p = "3";
            ManualDao ma = new ManualDao(ex);
            return a + ma.a;
        }
    }
}
