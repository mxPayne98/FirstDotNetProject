using System;

namespace FirstLib
{
    public class Division : Arithematic
    {
        private double a;
        private double b;

        public Division(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public override double calculate()
        {
            return this.a / this.b;
        }
    }
}
