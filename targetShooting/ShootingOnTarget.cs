using System;

namespace targetShooting
{
    enum PointsOnTarget
    {
        zone1 = 10, zone2 = 5, zone3 = 1, zone4 = 0
    };

    class ShootingOntarget
    {
        static void Main(string[] args)
        {
            int shotsNumber = 3;
            int targetMoveRadius = 2;
            int shotDisturbanceRadius = 1;
            double sumPoints = 0;
            string temp;
            double x, y, radiusSquared;
            PointsOnTarget points = PointsOnTarget.zone4;
            Random rnd = new Random();
    
            int targetMoveX = rnd.Next(-targetMoveRadius, targetMoveRadius);
            int targetMoveY = rnd.Next(-targetMoveRadius, targetMoveRadius);

            int shotDisturbanceX = rnd.Next(-shotDisturbanceRadius, shotDisturbanceRadius);
            int shotDisturbanceY = rnd.Next(-shotDisturbanceRadius, shotDisturbanceRadius);

            Console.WriteLine("You have {0} shots! ", shotsNumber);
            try {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Shoot! (Enter two numbers)");
                    temp = Console.ReadLine();
                    x = double.Parse(temp.Split()[0]);
                    y = double.Parse(temp.Split()[1]);
                    x += shotDisturbanceX;
                    y += shotDisturbanceY;
                    radiusSquared = (x - targetMoveX) * (x - targetMoveX) + (y - targetMoveY) * (y - targetMoveY);

                    Console.WriteLine("xc {0}, yc {1}, xs {2}, xs {3}", targetMoveX, targetMoveY, x, y);

                    if (radiusSquared <= 1)
                    {
                        points = PointsOnTarget.zone1;
                    }
                    else if (radiusSquared <= 4)
                    {
                        points = PointsOnTarget.zone2;
                    }
                    else if (radiusSquared <= 9)
                    {
                        points = PointsOnTarget.zone3;
                    }
                    else
                    {
                        points = PointsOnTarget.zone4;
                    }

                    sumPoints += (double)points;

                    targetMoveX = rnd.Next(-targetMoveRadius, targetMoveRadius);
                    targetMoveY = rnd.Next(-targetMoveRadius, targetMoveRadius);
                    shotDisturbanceX = rnd.Next(-shotDisturbanceRadius, shotDisturbanceRadius);
                    shotDisturbanceY = rnd.Next(-shotDisturbanceRadius, shotDisturbanceRadius);
                }

                Console.WriteLine("You got {0} points", sumPoints);
            } 
            catch(FormatException)
            {
                Console.WriteLine("Enter number instead of letter");
            }

            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Enter 2 numbers");
            }
            
         
        }
    }
}
