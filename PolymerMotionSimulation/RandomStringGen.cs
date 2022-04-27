using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PolymerMotionSimulation
{
    /// <summary>
    /// Random string generators.
    /// </summary>
    static class RandomStringGen
    {
        /// <summary>
        /// Get random string of 11 characters.
        /// </summary>
        /// <returns>Random string.</returns>
        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }
    }
}
