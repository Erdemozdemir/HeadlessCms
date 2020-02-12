using System;
using System.ComponentModel.DataAnnotations;

namespace EdufaceCms.WebApplication.DataAnnotations
{
    public class TCValidator:ValidationAttribute
    {
        public bool ShowInTable { get; set; }
        public override bool IsValid(object value)
        {
            var TCNo = value as string;
            int[] TC = new int[11];
            for (int i = 0; i < 11; i++)
            {
                string a = TCNo[i].ToString();
                TC[i] = Convert.ToInt32(a);
            }

            int tekler = 0;
            int ciftler = 0;

            for (int k = 0; k < 9; k++)
            {
                if (k % 2 == 0)
                    tekler += TC[k];
                else if (k % 2 != 0)
                    ciftler += TC[k];
            }

            int t1 = (tekler * 3) + ciftler;
            int c1 = (10 - (t1 % 10)) % 10;
            int t2 = c1 + ciftler;
            int t3 = (t2 * 3) + tekler;
            int c2 = (10 - (t3 % 10)) % 10;

            if (c1 == TC[9] && c2 == TC[10])
                return true;
            else
                return false;
        }
    }
}
