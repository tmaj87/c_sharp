using System;

namespace WpfApplication1
{
    public class Toolkit
    {
        public Random rand = new Random();

        public String getNewNumbers(int length)
        {
            if (length < 1)
            {
                return "";
            }

            System.Text.StringBuilder str = new System.Text.StringBuilder();
            for (int i = 0; i < length; i++)
            {
                str.Append(rand.Next(0, 9).ToString());
            }
            return str.ToString();
        }

        public String divideBy(int by, String number)
        {
            if (by <= 0)
            {
                return number;
            }

            System.Text.StringBuilder str = new System.Text.StringBuilder();
            for (int i = 0; i < number.Length; i++)
            {
                if (i % by == 0)
                {
                    str.Append(" ");
                }
                str.Append(number[i]);
            }

            return str.ToString();
        }
    }
}