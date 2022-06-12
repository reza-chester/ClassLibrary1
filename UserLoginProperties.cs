using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserPropertiesAD
{
    public sealed class UserLoginProperties
    {
        private static UserLoginProperties? _instance;
        private static string? myProperty;
        public static UserProperties? Properties;
        public string UserName
        {
            get => myProperty;
            set
            {
                if (myProperty == null)
                    myProperty = value;
            }
        }
        private UserLoginProperties() {}

        public static UserLoginProperties GetInstance()
        {
            if(_instance == null)
            {
                _instance = new UserLoginProperties();
            }
            return _instance;
        }

        public UserProperties GetProperties()
        {
            if(Properties == null)
                Properties = FillProperteis.GetProperties(myProperty);
            return Properties;
        }
    }
}
