using System;

namespace targetShooting
{
 
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

                    Console.WriteLine("Target center is at ({0},{1}). Disturbance of shooting is ({2},{3})", 
                        targetMoveX, targetMoveY, shotDisturbanceX, shotDisturbanceY);

                    if (radiusSquared <= 1)
                    {
                        sumPoints += 10;
                    }
                    else if (radiusSquared <= 4)
                    {
                        sumPoints += 5;
                    }
                    else if (radiusSquared <= 9)
                    {
                        sumPoints += 1;
                    }

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
