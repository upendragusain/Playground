namespace CSharpGeneral
{
    /*
     * A return type of a method is not part of the signature of the method for the purposes of method overloading.
     * calling code pass arguments for each parameter
     */
    public abstract class Motorcycle
    {
        // Anyone can call this.
        public void StartEngine() {/* Method statements here */ }

        // Only derived classes can call this.
        protected void AddGas(int gallons) { /* Method statements here */ }

        // Derived classes can override the base class implementation.
        public virtual int Drive(int miles, int speed) { /* Method statements here */ return 1; }

        // Derived classes must implement this.
        public abstract double GetTopSpeed();
    }

    public class Honda : Motorcycle
    {
        public override double GetTopSpeed()
        {
            return 150;
        }

        public override int Drive(int miles, int speed)
        {
            AddGas(miles);
            StartEngine();
            return miles * speed;
        }
    }

    public class Methods
    {
        public static void Run()
        {
            var honda = new Honda();
            honda.Drive(100, 80);
        }
    }
}
