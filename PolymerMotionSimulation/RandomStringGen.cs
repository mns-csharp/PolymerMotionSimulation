using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PolymerMotionSimulation
{
    /// <summary>
    /// Random string generators.
    /// </summary>
    public static class RandomStringGen
    {
        private static List<char> charList = new List<char>(new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k','l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' });
        /// <summary>
        /// Get random string of 11 characters.
        /// </summary>
        /// <returns>Random string.</returns>
        public static string GetRandomString()
        {
            int index = Global.Random.Next(0, 26);
            char ch1 = charList[index];

            index = Global.Random.Next(0, 26);
            char ch2 = charList[index];

            index = Global.Random.Next(0, 26);
            char ch3 = charList[index];

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}{2}", ch1, ch2, ch3);

            return sb.ToString().ToUpper();
        }
    }
}
