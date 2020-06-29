using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CSharp7
{
    /*
     * Members of a class can't have signatures that differ only by ref, in, or out. A compiler error occurs
     * However, methods can be overloaded when one method has a ref, in, or out parameter and the other has a value parameter
     * 
     * In some cases, accessing a value by reference increases performance by avoiding a potentially expensive copy operation
     */

    public class RefExamples
    {
        public static void PassByRef(ref int id)
        {
            id = 42;
        }

        public static ref int FindLargest(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] == array.Max())
                {
                    return ref array[i];
                }
            }
            throw new ArgumentException();
        }

        //i will give you a ref type that you can not chaage
        public static ref readonly int RefReadonly(int[] array)
        {
            return ref array[0];
        }
    }

    public class Library
    {
        public class Book
        {
            public string Title { get; set; }
        }

        private Book[] _books = {
            new Book { Title = "Call of the Wild, The" },
            new Book { Title = "Tale of Two Cities, A" }
                       };

        private Book nobook = null;

        public Book[] ListBooks()
        {
            return _books;
        }

        public ref Book GetABookThatCanBeReplaced(string title)
        {
            for (int i = 0; i < _books.Count(); i++)
            {
                if(_books[i].Title == title)
                {
                    return ref _books[i];
                }
            }

            return ref nobook;
        }
    }
}
