using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RestApp.Common.Helpers
{
    public interface IFilesHelper
    {
        byte[] ReadFully(Stream input);
    }

}
