using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string dbFile = "Students.dat";
            const string directory = "C:/Users/rupakal/Desktop/Students";
            Student[] students;
            Console.OutputEncoding = Encoding.UTF8;
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream(dbFile, FileMode.Open))
            {
                students = (Student[])formatter.Deserialize(fs);
            }
            CreateDirectory(directory);
            CreateAndFillFiles(directory,students);
            Console.ReadKey();
        }
        static void CreateDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }
            Directory.CreateDirectory(directory);
        }
        static void CreateAndFillFiles(string directory, Student[] students)
        {
            string _name;
            string _group;
            string _dateOfBirth;
            foreach (var student in students)
            {
                _name = student.Name;
                _group = student.Group;
                _dateOfBirth = student.DateOfBirth.Date.ToString("d");
                using (StreamWriter sw = File.AppendText(directory + "/" + student.Group + ".txt"))
                {
                    sw.WriteLine($"{_group} {_name} {_dateOfBirth}\n");
                }
            }
        }
    }
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
