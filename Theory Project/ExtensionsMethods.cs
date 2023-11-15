using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theory_Project
{
    public static class ExtensionsMethods
    {
        public static bool IsDuplicatePresent(this List<string> list)
        {
            foreach (string item in list)
            {
                int index1 = list.IndexOf(item);
                int index2 = list.LastIndexOf(item);
                if (!index1.Equals(index2))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
