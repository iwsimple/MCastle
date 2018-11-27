using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Configuration;
using System.Reflection;
using System.Xml;

namespace MCastle.IoC
{
    /// <summary>
    /// IoC
    /// </summary>
    public class IocContainer
    {
        private IWindsorContainer _windsor;
        private static IocContainer _install = null;
        private static readonly object _lock = new object();

        public IocContainer()
        {
            _windsor = new WindsorContainer().Install(
                FromAssembly.This(),
                Castle.Windsor.Installer.Configuration.FromAppConfig()
                );
        }

        /// <summary>
        /// static成员变量自动初始化赋值_install
        /// </summary>
        public static IocContainer Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_install == null)
                        _install = new IocContainer();
                    return _install;
                }
            }
        }

        public static IocContainer Instances()
        {
            lock (_lock)
            {
                if (_install == null)
                    _install = new IocContainer();
                return _install;
            }
        }

        public static IWindsorContainer GetContainer()
        {
            Instances();
            return Instance._windsor;
        }

        public static T Get<T>()
        {
            return GetContainer().Resolve<T>();
            //return Resolve<T>();
        }

        /// <summary>
        /// Resolve内部实现
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            //配置文件中AppSetting节点匹配T类型的Name，返回service
            //<component id="supplierAccountDao" service="PCMS.Core.IDao.ISupplierAccountDao, PCMS.Core" type="PCMS.Core.Dao.SupplierAccountDao, PCMS.Core"></component>
            //service="PCMS.Core.IDao.ISupplierAccountDao, PCMS.Core";
            string service = System.Configuration.ConfigurationManager.AppSettings[typeof(T).Name];
            string service1 = service.Split(',')[1];
            string service0 = service.Split(',')[0];
            Assembly assembly = Assembly.Load(service1);
            Type type = assembly.GetType(service0);
            //利用反射创建实现类
            return (T)Activator.CreateInstance(type);
        }

        /// <summary>
        /// Resolve内部猜测，不对，不知道
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve1<T>()
        {
            //配置文件中AppSetting节点匹配T类型的Name，返回service
            //<component id="supplierAccountDao" service="PCMS.Core.IDao.ISupplierAccountDao, PCMS.Core" type="PCMS.Core.Dao.SupplierAccountDao, PCMS.Core"></component>
            //service="PCMS.Core.IDao.ISupplierAccountDao, PCMS.Core";
            XmlNode service = (XmlNode)System.Configuration.ConfigurationManager.GetSection("castle");
            XmlNodeList list = service.ChildNodes;
            foreach (XmlNode xn in list)
            {
                ConfigurationFileMap cfm = new ConfigurationFileMap("file://Castle.Services.Core.config");
                //ConfigurationFileMap uri =xn.Attributes["uri"] as ConfigurationFileMap;
                //XmlNode namespaceURI =xn.OuterXml as XmlNode;
                System.Configuration.Configuration con = System.Configuration.ConfigurationManager.OpenMappedMachineConfiguration(cfm);

            }
            //string service1 = service.Split(',')[1];
            //string service0 = service.Split(',')[0];
            //Assembly assembly = Assembly.Load(service1);
            //Type type = assembly.GetType(service0);
            ////利用反射创建实现类
            //return (T)Activator.CreateInstance(type);
            return (T)new object();
        }
    }
}
