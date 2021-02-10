namespace convert_all
{

    public class weight
    {
        public double PoundsToKilogram(double pounds)
        {
            return (pounds * 0.45359237);
        }

        public double PoundsToStones(double pounds)
        {
            return (pounds * 0.071428571);
        }

        public double KilogramsToPounds(double kilogram)
        {
            return (kilogram * 2.206226);
        }

        public double KilogramsToStones(double kilogram)
        {
            return (kilogram * 0.15747304);
        }

        public double StonesToPounds(double stones)
        {
            return (stones * 14);
        }

        public double StonesToKilogram(double stones)
        {
            return (stones * 6.3502932);
        }
    }
}
