using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpGeneral
{
    /*
     * C# passes all reference types by value, and the value of an array reference is the pointer to the array
     * Passing by reference enables..to change the value of the parameters and have that change persist in the calling environment
     * 
     * To pass a parameter by reference with the intent of changing the value, use the ref, or out keyword. 
     * To pass by reference with the intent of avoiding copying but not changing the value, use the in modifier.
     * 
     * A value-type variable contains its data directly as opposed to a reference-type variable, which contains a reference to its data. Passing a value-type variable to a method by value means passing a copy of the variable to the method. Any changes to the parameter that take place inside the method have no effect on the original data stored in the argument variable. If you want the called method to change the value of the argument, you must pass it by reference, using the ref or out keyword. 
     * You may also use the in keyword to pass a value parameter by reference to avoid the copy while guaranteeing that the value will not be changed.
     * 
     * the contents of a value type are copied into the parameter
     * 
     * When a reference type is passed by value to a method, the method receives a copy of the reference to the class instance. 
     * That is, the called method receives a copy of the address of the instance, and the calling method retains the original address of the instance.
     * The class instance in the calling method has an address, the parameter in the called method has a copy of the address, 
     * and both addresses refer to the same object
     * 
     * Because a struct is a value type, when you pass a struct by value to a method, the method receives and operates on a copy of the struct argument. The method has no access to the original struct in the calling method and therefore can't change it in any way. 
     */
    public class PassingParameters
    {
        public static void SquareItByVal(int num)
        {
            num *= num;
        }

        public static void SquareItByRef(ref int num)
        {
            num *= num;
        }

        public static void PassingRefTypesByValue(int[] array)
        {
            //update will be reflected in the calling code
            array[0] = 42;

            //this however dereferences it and now it poinst t something else
            //so we have created the second array only living inside this method
            array = new int[] { 69 };
        }

        public static void PassingRefTypesByRef(ref int[] array)
        {
            //update will be reflected in the calling code
            array[0] = 42;

            // losing the above update
            // we have now made the ref point to another array, basically overwritting it
            // bacause the ref type was now passed by ref we have full control to change it and the changes will persit in the calling code
            array = new int[] { 69 };
        }

        /*
         * Defining methods using in parameters is a potential performance optimization. 
         * Some struct type arguments may be large in size, and when methods are called in tight loops or critical code paths, the cost of copying those structures 
         * is critical. Methods declare in parameters to specify that arguments may be passed by reference safely because the called method does not modify the 
         * state of that argument. Passing those arguments by reference avoids the (potentially) expensive copy.
         */
        public static void InArgsExample(in int num)
        {
            // compile error, num is readonly!
            //num++;
        }
    }
}
