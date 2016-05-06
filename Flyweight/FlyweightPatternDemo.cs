using System;

//A flyweight is an object that minimizes memory use by sharing
//as much data as possible with other similar objects.
//Often some parts of the object state can be shared, and it is common practice to hold them in external data structures
//and pass them to the flyweight objects temporarily when they are used.

//Flyweight allows you to share bulky data which are common to each object.
//In other words, if you think that same data is repeating for every object,
//you can use this pattern to point to the single object and hence can easily save space.

//Whereas Flyweight shows how to make lots of little objects, 
//Facade shows how to make a single object represent an entire subsystem.


namespace Flyweight
{
    public class FlyweightPatternDemo
    {
        private static readonly string[] colors = new string[] { "Red", "Green", "Blue", "White", "Black" };

        private static Random rnd = new Random();

        public static void Main()
        {
            for (int i = 0; i < 20; ++i)
            {
                Circle circle = (Circle)ShapeFactory.getCircle(getRandomColor());
                circle.setX(getRandomX());
                circle.setY(getRandomY());
                circle.setRadius(100);
                circle.draw();
            }
        }

        private static string getRandomColor() {
            return colors[(rnd.Next(1, colors.Length))];
       }
       private static int getRandomX() {
           return (rnd.Next(1, 100));
       }
       private static int getRandomY() {
           return (rnd.Next(1, 100));
       }
    }
}