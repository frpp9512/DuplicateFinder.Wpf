using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFinder
{
    public static class Toolkit
    {
        public static string GetSizeString(long size)
        {
            string[] mu = { "Bytes", "KB", "MB", "GB", "TB" };
            var iterations = 0;
            decimal convertedSize = size;
            while (convertedSize > 1024)
            {
                convertedSize /= 1024;
                iterations++;
            }
            return $"{decimal.Round(convertedSize, 2, MidpointRounding.AwayFromZero)} {(iterations < mu.Length ? mu[iterations] : "NONE")}";
        }
    }
}
