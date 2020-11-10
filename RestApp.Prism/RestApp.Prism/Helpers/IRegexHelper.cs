using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Prism.Helpers
{
    public interface IRegexHelper
    {
        bool IsValidEmail(string emailaddress);
    }

}
