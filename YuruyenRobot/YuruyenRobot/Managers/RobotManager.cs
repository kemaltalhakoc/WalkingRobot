using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuruyenRobot.Managers
{
    enum direction {N, W, S, E}

    class RobotManager : ICloneable
    {
        internal int maxx { get; set; }
        internal int maxy { get; set; }
        internal int x { get; set; }
        internal int y { get; set; }
        internal direction direct { get; set; }

        public object Clone() // Icloneable interface zorunlu fonksiyonu
        {
            return this.MemberwiseClone();
        }

        internal string AllMove(string commands)
        {
            string result = "";
            foreach (char c in commands)
            {
                if (OneMove(c) == false)
                    return "Command Error!!! the command only consist of 'L','R','M' !!!";
            }
            result = x.ToString() + " " + y.ToString() + " " + direct;
            return result;
        }
       
        private bool OneMove(char command)
        {
            if (command == 'L')
            {
                if (direct == direction.E)
                    direct = direction.N;
                else if (direct == direction.N)
                    direct = direction.W;
                else if (direct == direction.W)
                    direct = direction.S;
                else if (direct == direction.S)
                    direct = direction.E;
            }
            else if (command == 'R')
            {
                if (direct == direction.E)
                    direct = direction.S;
                else if (direct == direction.S)
                    direct = direction.W;
                else if (direct == direction.W)
                    direct = direction.N;
                else if (direct == direction.N)
                    direct = direction.E;
            }
            else if (command == 'M')
            {
                if (direct == direction.E)
                    x = x + 1 < maxx ? x+1 : maxx;
                else if (direct == direction.S)
                    y = y - 1 > 0 ? y-1 : 0;
                else if (direct == direction.W)
                    x = x - 1 > 0 ? x-1 : 0;
                else if (direct == direction.N)
                    y = y + 1 < maxy ? y+1 : maxy;
                
            }
            else
                return false;
           
            return true;
        }

    }
}
