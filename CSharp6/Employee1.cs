namespace CSharp6
{
    namespace readonly_auto_properties
    {
        public class Employee1
        {
            public string Name_ReadonlyAuto { get; }

            private readonly string name_Readonly_Explicit;

            public Employee1(string name)
            {
                Name_ReadonlyAuto = name;
            }

            /*
             * readonly properties can only be assigned to in the class constructor
             * c#6 allows readonly auto prperties (w/o the use of the 'readonly' keyword)
             * compilation error!
             */
            public void SetName(string name)
            {
                //Name_ReadonlyAuto = name;
                //name_Readonly_Explicit = name;
            }
        }
    }
}
