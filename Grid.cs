using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SudokuNet
{
    public class Grid
    {
        public int[,] values { get; set; } = new int[9, 9];
        
        public Grid() { }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    sb.Append(values[i, j]);
                    sb.Append(' ');
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
