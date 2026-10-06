namespace Mika2027.Models
{
    public class Material
    {
        public string FiberName { get; set; }
        public int Percent { get; set; }

        public override string ToString()
        {
            if (Percent > 0)
            {
                return $"{Percent}% {FiberName}";
            }
            else
            {
                return FiberName;
            }
        }
    }
}