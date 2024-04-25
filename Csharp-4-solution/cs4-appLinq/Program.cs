using System;
using System.Collections.Generic;
using System.Linq;
using static cs4_appLinq.Program;

namespace cs4_appLinq
{
    internal class Program
    {
        public class Patient
        {
            public int id { get; set; }
            public string name { get; set; }
            public string lastname { get; set; }
            public string sex { get; set; }
            public double temperature { get; set; }
            public int heartRate { get; set; }
            public string specialty { get; set; }
            public int age { get; set; }
        }
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>
            {
                  new Patient{
                    id= 1,
                    name= "John",
                    lastname= "Doe",
                    sex= "Male",
                    temperature= 36.8,
                    heartRate= 80,
                    specialty= "general medicine",
                    age= 44,
                  },
                  new Patient{
                    id= 2,
                    name= "Jane",
                    lastname= "Doe",
                    sex= "Female",
                    temperature= 36.8,
                    heartRate= 70,
                    specialty= "general medicine",
                    age= 43,
                  },
                  new Patient{
                    id= 3,
                    name= "Junior",
                    lastname= "Doe",
                    sex= "Male",
                    temperature= 36.8,
                    heartRate= 90,
                    specialty= "pediatrics",
                    age= 8,
                  },
                  new Patient{
                    id= 4,
                    name= "Mary",
                    lastname= "Wien",
                    sex= "Female",
                    temperature= 36.8,
                    heartRate= 120,
                    specialty= "general medicine",
                    age= 20,
                  },
                  new Patient{
                    id= 5,
                    name= "Scarlett",
                    lastname= "Somez",
                    sex= "Female",
                    temperature= 36.8,
                    heartRate= 110,
                    specialty= "general medicine",
                    age= 30,
                  },
                  new Patient{
                    id= 6,
                    name= "Brian",
                    lastname= "Kid",
                    sex= "Male",
                    temperature= 39.8,
                    heartRate= 80,
                    specialty= "pediatrics",
                    age= 11,
                  }
            };
            // EJ 1
            Console.WriteLine("[1. Extract a list of patients from ´pediatrics´ under 10 years of age.]");
            var pediatricsKids = patients.Where(p => p.specialty == "pediatrics" && p.age <= 10);
            foreach (var patient in pediatricsKids)
            {
                Console.WriteLine($"{patient.name} {patient.lastname} -> Age: {patient.age} & Speciality {patient.specialty}");
            }
            Console.WriteLine("\n-- press enter to view the next exercise --\n");
            Console.ReadLine();

            // EJ 2
            Console.WriteLine("[2. Check if there are any patients with heart rate over 100 or temperature over 39");
            var patientsCritical = patients.Where(p => p.temperature >= 39 || p.heartRate >= 100);
            foreach (var patient in patientsCritical)
            {
                Console.WriteLine($"{patient.name} {patient.lastname} -> Temperature: {patient.temperature} & HeartRate {patient.heartRate}");
            }
            if (patients.Count > 0)
            {
                Console.WriteLine($"\nUrgency protocol raised, there are {patientsCritical.Count()} patients in critical conditions.");
            }
            Console.WriteLine("\n--  press enter to view the next exercise  --\n");
            Console.ReadLine();

            // EJ 3
            Console.WriteLine("[3. Create a new collection where patients from pediatrics have been moved to general medicine");
            var patientsTomorrow = from patient in patients where patient.specialty == "pediatrics" select new { id = patient.id, name = patient.name, lastname = patient.lastname, age = patient.age, heartRate = patient.heartRate, temperature = patient.temperature, sex = patient.sex, specialty = "general medicine" };
            foreach (var patient in patientsTomorrow)
            {
                Console.WriteLine($"{patient.name} {patient.lastname} -> Age: {patient.age} & Speciality {patient.specialty}");
            }
            Console.WriteLine("\n-- press enter to view the next exercise --\n");
            Console.ReadLine();

            // EJ 4
            Console.WriteLine("[4. Tell from a single query the number of patients from general medicine and pediatrics");
            var patientsSpeciality = patients.GroupBy(p => p.specialty);
            foreach (var speciality in patientsSpeciality)
            {
                Console.WriteLine($"{speciality.Key} has {speciality.Count()} people assigned.");
            }

            Console.WriteLine("\n-- press enter to view the next exercise --\n");
            Console.ReadLine();

            // EJ 5
            Console.WriteLine("[5. Create a new collection for patients from exercise 2.]");
            var patientsPriority = from patient 
                                   in patients 
                                   where patient.heartRate >= 100 || patient.temperature >= 39 
                                   select new { 
                                       id = patient.id, 
                                       name = patient.name, 
                                       lastname = patient.lastname, age = patient.age, heartRate = patient.heartRate, temperature = patient.temperature, sex = patient.sex, specialty = "general medicine" };
            foreach (var patient in patientsPriority)
            {
                Console.WriteLine($"{patient.name} {patient.lastname} -> Temperature: {patient.temperature} & HeartRate {patient.heartRate}");
            }
            Console.WriteLine("\n-- press enter to view the next exercise --\n");
            Console.ReadLine();

            // EJ 6
            Console.WriteLine("[6. Tell from a single query the number of patients from general medicine and pediatrics");
            var averageAges = patients.GroupBy(p => p.specialty);
            foreach (var speciality in averageAges)
            {
                Console.WriteLine($"Patients in {speciality.Key} are in average {speciality.Average(x => x.age)} years old.");
            }

            Console.WriteLine("\n-- press enter to end the showcase --\n");
            Console.ReadLine();
        }
    }
}
