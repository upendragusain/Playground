using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8
{
    namespace xmlSerialization
    {
        public class XMLWrite
        {
            public class Book
            {
                public int Id { get; set; }
                public string Title { get; set; }
                public string Author { get; set; }
                public DateTime ReleaseDate { get; set; }

                public Publication Publisher { get; set; }
            }

            public class Publication
            {
                public int Id { get; set; }
                public string Name { get; set; }
            }

            public static void WriteXML()
            {
                Book book = new Book()
                {
                    Id = 23,
                    Title = "Book Title",
                    Author = "Author",
                    ReleaseDate = DateTime.Now.AddYears(-10),
                    Publisher = new Publication()
                    {
                        Id = 234,
                        Name = "Peguin"
                    }
                };

                System.Xml.Serialization.XmlSerializer writer =
                    new System.Xml.Serialization.XmlSerializer(typeof(Book));

                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
                System.IO.FileStream file = System.IO.File.Create(path);

                writer.Serialize(file, book);
                file.Close();
            }
        }
    }

    namespace struct_with_interface
    {
        public interface INotify
        {
            string notify();
        }

        public struct Point : INotify
        {
            public int X { get; set; }
            public int Y { get; set; }

            public string notify()
            {
                return $"I am a {typeof(Point)} with x:{X} and y:{Y}";
            }
        }

        public class StructWithInterface
        {
            public static void Run()
            {
                Point point = new Point()
                {
                    X = 12,
                    Y = 45
                };
                Console.WriteLine(point.notify());
            }
        }
    }

    namespace type_conversion
    {
        public class Animal
        {
            public string Eat()
            {
                return "Animal eating";
            }
        }

        public class Giraffe : Animal
        {
            public string StrechNeck()
            {
                return "Giraffe strecthing long neck";
            }
        }

        public class Lion : Animal
        {
            public string Roar()
            {
                return "Lion roaring";
            }
        }

        public class Test
        {
            public static void Run()
            {
                Giraffe giraffe = new Giraffe();

                //Animal a = g;

                Animal lion = new Lion();
                //this gives error as l (lion) is an animal but not a giraffe
                //Giraffe g2 = (Giraffe)l;
                //g2.StrechNeck();

                // use "is" instead
                if(lion is Giraffe)
                {
                    Console.WriteLine("correct conversion to a Giraffe Type");
                }
                else
                {
                    Console.WriteLine($"trying to convert {lion.GetType()} to a Giraffe Type");
                }
                
            }
        }
    }


}
