namespace Tyre
{

    public class Sizes
    {
        public static int bicycle(string size)
        {
            int circumference = 0;

            switch (size)
            {
                case "12\" x 1.75\"": circumference = 935; break;
                case "12\" x 1.95\"": circumference = 940; break;
                case "14\" x 1.50\"": circumference = 1020; break;
                case "14\" x 1.75\"": circumference = 1055; break;
                case "16\" x 1.50\"": circumference = 1185; break;
                case "16\" x 1.75\"": circumference = 1195; break;
                case "16\" x 1-1/8\"": circumference = 1290; break;
                case "16\" x 1-3/8\"": circumference = 1300; break;
                case "16\" x 2.00\"": circumference = 1245; break;
                case "18\" x 1.50\"": circumference = 1340; break;
                case "18\" x 1.75\"": circumference = 1350; break;
                case "20\" x 1.25\"": circumference = 1450; break;
                case "20\" x 1.35\"": circumference = 1460; break;
                case "20\" x 1.50\"": circumference = 1490; break;
                case "20\" x 1.75\"": circumference = 1515; break;
                case "20\" x 1.95\"": circumference = 1565; break;
                case "20\" x 1-1/8\"": circumference = 1545; break;
                case "20\" x 1-3/8\"": circumference = 1615; break;
                case "22\" x 1-1/2\"": circumference = 1785; break;
                case "22\" x 1-3/8\"": circumference = 1770; break;
                case "24\" x 1\"": circumference = 1753; break;
                case "24\" x 1.75\"": circumference = 1890; break;
                case "24\" x 1-1/4\"": circumference = 1905; break;
                case "24\" x 1-1/8\"": circumference = 1795; break;
                case "24\" x 2.00\"": circumference = 1925; break;
                case "24\" x 2.125\"": circumference = 1965; break;
                case "24\" x 3/4\" Tubular": circumference = 1785; break;
                case "26\" x 1\"": circumference = 1952; break;
                case "26\" x 1.25\"": circumference = 1950; break;
                case "26\" x 1.40\"": circumference = 2005; break;
                case "26\" x 1.50\"": circumference = 2010; break;
                case "26\" x 1.75\"": circumference = 2023; break;
                case "26\" x 1.95\"": circumference = 2050; break;
                case "26\" x 1-1.0\"": circumference = 1913; break;
                case "26\" x 1-1/2\"": circumference = 2100; break;
                case "26\" x 1-1/8\"": circumference = 1970; break;
                case "26\" x 1-3/8\"": circumference = 2068; break;
                case "26\" x 2.00\"": circumference = 2055; break;
                case "26\" x 2.1\"": circumference = 2068; break;
                case "26\" x 2.125\"": circumference = 2070; break;
                case "26\" x 2.35\"": circumference = 2083; break;
                case "26\" x 3.00\"": circumference = 2170; break;
                case "26\" x 7/8\" Tubular": circumference = 1920; break;
                case "27\" x 1\"": circumference = 2145; break;
                case "27\" x 1-1/4\"": circumference = 2161; break;
                case "27\" x 1-1/8\"": circumference = 2155; break;
                case "27\" x 1-3/8\"": circumference = 2169; break;
                case "27.5\" x 1.50\"": circumference = 2079; break;
                case "27.5\" x 1.95\"": circumference = 2090; break;
                case "27.5\" x 2.10\"": circumference = 2148; break;
                case "27.5\" x 2.25\"": circumference = 2182; break;
                case "29\" x 2.1\"": circumference = 2288; break;
                case "29\" x 2.2\"": circumference = 2298; break;
                case "29\" x 2.25\"": circumference = 2281; break;
                case "29\" x 2.3\"": circumference = 2326; break;
                case "700C Tubular": circumference = 2130; break;
                case "700 x 47C": circumference = 2268; break;
                case "700 x 45C": circumference = 2242; break;
                case "700 x 44C": circumference = 2235; break;
                case "700 x 40C": circumference = 2200; break;
                case "700 x 38C": circumference = 2180; break;
                case "700 x 35C": circumference = 2168; break;
                case "700 x 32C": circumference = 2155; break;
                case "700 x 30C": circumference = 2146; break;
                case "700 x 28C": circumference = 2136; break;
                case "700 x 25C": circumference = 2105; break;
                case "700 x 23C": circumference = 2096; break;
                case "700 x 20C": circumference = 2086; break;
                case "700 x 19C": circumference = 2080; break;
                case "700 x 18C": circumference = 2070; break;
                case "650 x 38B": circumference = 2105; break;
                case "650 x 38A": circumference = 2125; break;
                case "650 x 35A": circumference = 2090; break;
                case "650 x 23C": circumference = 1944; break;
                case "650 x 20C": circumference = 1938; break;
                default: circumference = 0; break;
            }
            return (circumference);
        }
    }
}
