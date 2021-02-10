using System.Collections.Generic;

namespace convert_all
{

    public class height
{
        static KeyValuePair<int, double> MetreToFeetInches(double metre)
        {
            double inches = metre * 39.370079;
            return new KeyValuePair<int, double>((int)inches / 12, inches % 12);
        }

        public static double FeetInchesToMetres(double feet, double inches)
        {
            return ((feet * 12) + inches)*0.0253999;
        }

        public static double FeetToInches(double feet, double inches)
        {
            return ((feet*12) + inches);
        }

        public static double InchesToMetre(double inches)
        {
            return (inches * 0.0254);
        }

        public static double MetresToFeet(double Metre)
        {
            return (Metre * 3.2808399);
        }

        public static double FeetToMetre(double Feet)
        {
            return (Feet * 0.304800610);
        }
    }
}

