using System;
using System.Collections.Generic;

namespace Flyweight
{
    public class ShapeFactory
    {
        private static Dictionary<String, Circle> circleMap = new Dictionary<String, Circle>();

           public static IShape getCircle(String color)
           {
               Circle circle;
               
               circleMap.TryGetValue(color, out circle);

              if(circle == null) {
                 circle = new Circle(color);
                 circleMap.Add(color, circle);
                 Console.WriteLine("Creating circle of color : " + color);
              }
              return circle;
           }
    }
}