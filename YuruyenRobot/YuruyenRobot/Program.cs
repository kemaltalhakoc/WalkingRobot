using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuruyenRobot.Managers;

namespace YuruyenRobot
{
    class Program
    {
        static void Main(string[] args)
        {           

            Console.Write("Please Enter the max area coordinates (maxx maxy):");
            string command = Console.ReadLine();
            string[] maxxcoordinat;
            maxxcoordinat = command.Split(' ');

            Console.Write("Please Enter the first Robot's location (x y direction):");
            command = Console.ReadLine();
            string[] robot1coordinat;
            robot1coordinat = command.Split(' ');

            Console.Write("Please Enter the first Robot's NasaCommands (only consist of 'L','R','M'):");
            string robot1command = Console.ReadLine();

            Console.Write("Please Enter the second Robot's location (x y direction):");
            command = Console.ReadLine();
            string[] robot2coordinat;
            robot2coordinat = command.Split(' ');

            Console.Write("Please Enter the second Robot's NasaCommands (only consist of 'L','R','M'):");
            string robot2command = Console.ReadLine();

            try
            {
                RobotManager robotManager1 = new RobotManager();

                robotManager1.maxx = Convert.ToInt32(maxxcoordinat[0].ToString());
                robotManager1.maxy = Convert.ToInt32(maxxcoordinat[1].ToString());
                robotManager1.x = Convert.ToInt32(robot1coordinat[0].ToString());
                robotManager1.y = Convert.ToInt32(robot1coordinat[1].ToString());
                robotManager1.direct = (direction)Enum.Parse(typeof(direction), robot1coordinat[2].ToString());

                RobotManager robotManager2 = (RobotManager)robotManager1.Clone();
                robotManager2.x = Convert.ToInt32(robot2coordinat[0].ToString()); 
                robotManager2.y = Convert.ToInt32(robot2coordinat[1].ToString()); 
                robotManager2.direct = (direction)Enum.Parse(typeof(direction), robot2coordinat[2].ToString());
                string result1 = robotManager1.AllMove(robot1command);
                string result2 = robotManager2.AllMove(robot2command);
                Console.WriteLine(result1);
                Console.WriteLine(result2);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error input arguments! :" + ex.Message);
            }
                        
            Console.ReadLine();
        }
    }
}
