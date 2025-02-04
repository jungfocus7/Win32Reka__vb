using System;



namespace ConsoleApp1
{
    public static class TesterProgram
    {
        private const string _numChars = "-0123456789";
        private static int prFindLen(char[] charr)
        {
            if ((charr == null) || (charr.Length == 0)) return 0;

            int ri = 0;
            foreach (char ch in charr)
            {
                int fi = _numChars.IndexOf(ch);
                if (fi < 0) break;
                else ++ri;
            }

            return ri;
        }
        public static int GetCompleteNumber(char[] charr)
        {
            int rn = 0;
            if ((charr != null) && (charr.Length > 0))
            {
                //s_xxx
                //charr.Ind
                int fi = Array.IndexOf(charr, '\0');
                if (fi > -1)
                {
                }
            }

            return rn;
        }
        public static void Main(string[] args)
        {
            ////string nstr = "0123\0\0\0\0";
            //string nstr = "9982ac32";
            //char[] charr = nstr.ToCharArray();
            //prFindLen(charr);
            //new string(charr, 0, l);

/*
            string nstr1 = "0123\0\0\0\0";
            nstr1.In
            //string nstr2 = "\0\0abc\0\0";
            prFindLastIndex(nstr1.ToCharArray());

            char[] charr = nstr1.ToCharArray()
            new string(new char[] { })
*/

            //var x0 = '\0';
            //var x1 = string.IsNullOrWhiteSpace(x0);
            //char num = '2';
            //var x0 = num - 2;

            /*
            string txt = "\0\0\0\0";
            char[] arr = txt.ToCharArray();
            txt = txt.Trim();
            string txt2 = Convert.ToString(arr);
            string txt3 = new string(arr);
            txt3 = txt3.Trim('\0');

            int nNum = Convert.ToInt32(arr);
            */
        }
    }
}
