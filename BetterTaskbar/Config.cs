using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterTaskbar
{
    internal class Config
    {

        public int[] iconSize = { 0, 0 };
        public string[] shortcutPaths = null;

        private void AddPaths(string newPath)
        {
            shortcutPaths.Append(newPath);
        }

        private void UpdatePaths(string[] validPaths)
        {
            shortcutPaths = validPaths;
        }

    }

    
}
