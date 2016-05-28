using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogInfo
{
    class Console : OuterSource
    {

        public override void Write(string message)
        {
            try
            {
                System.Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                Logger.Instance.Warning(ex.ToString());
            }
        }
    }
}
