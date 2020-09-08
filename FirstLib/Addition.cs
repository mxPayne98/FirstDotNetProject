namespace FirstLib
{
    public class Addition : Arithematic
    {
        private double a;
        private double b;

        public Addition(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public override double calculate()
        {
            return this.a + this.b;
        }
    }
}
