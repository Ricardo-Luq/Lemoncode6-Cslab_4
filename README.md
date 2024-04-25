# Lemoncode6-Cslab_4
Laboratory made for trying out Linq

## Tasks:
Given a list of patients with id, name, lastname, sex, temperature, heartRate, specialty and age, create a class Patient and a collection to store that list.
```cs
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
```

__1. Extract a list of patients from ´pediatrics´ under 10 years of age.__
```cs
      var pediatricsKids = patients.Where(p => p.specialty == "pediatrics" && p.age <= 10);
      foreach (var patient in pediatricsKids) {
          Console.WriteLine($"{patient.name} {patient.lastname} -> Age: {patient.age} & Speciality {patient.specialty}");
      }

```
__2. Check if there are any patients with heart rate over 100 or temperature over 39__
```cs
      var patientsCritical = patients.Where(p => p.temperature >= 39 || p.heartRate >= 100);
      foreach (var patient in patientsCritical) {
          Console.WriteLine($"{patient.name} {patient.lastname} -> Temperature: {patient.temperature} & HeartRate {patient.heartRate}");
      }
      if (patients.Count > 0) {
          Console.WriteLine($"\nUrgency protocol raised, there are {patientsCritical.Count()} patients in critical conditions.");
      }
```
__3. Create a new collection where patients from pediatrics have been moved to general medicine__
```cs
      var patientsTomorrow = from patient in patients
                            where patient.specialty == "pediatrics"
                            select new {
                              id = patient.id,
                              name = patient.name,
                              lastname = patient.lastname,
                              age = patient.age,
                              heartRate = patient.heartRate,
                              temperature = patient.temperature,
                              sex = patient.sex,
                              specialty = "general medicine"
                              };
      foreach (var patient in patientsTomorrow) {
          Console.WriteLine($"{patient.name} {patient.lastname} -> Age: {patient.age} & Speciality {patient.specialty}");
      }
```
__4. Tell from a single query the number of patients from general medicine and pediatrics__
```cs
      var patientsSpeciality = patients.GroupBy(p => p.specialty);
      foreach (var speciality in patientsSpeciality){
          Console.WriteLine($"{speciality.Key} has {speciality.Count()} people assigned.");
      }
```
__5. Create a new collection for patients from exercise 2.__
```cs
            var patientsPriority = from patient 
                                   in patients 
                                   where patient.heartRate >= 100 || patient.temperature >= 39 
                                   select new { 
                                   id = patient.id, 
                                   name = patient.name, 
                                   lastname = patient.lastname,
                                   age = patient.age,
                                   heartRate = patient.heartRate,
                                   temperature = patient.temperature,
                                   sex = patient.sex,
                                   specialty = "general medicine"
                                   };
            foreach (var patient in patientsPriority) {
                Console.WriteLine($"{patient.name} {patient.lastname} -> Temperature: {patient.temperature} & HeartRate {patient.heartRate}");
            }
```
__6. Tell from a single query the number of patients from general medicine and pediatrics__
```cs
      var averageAges = patients.GroupBy(p => p.specialty);
      foreach (var speciality in averageAges) {
          Console.WriteLine($"Patients in {speciality.Key} are in average {speciality.Average(x => x.age)} years old.");
      }
```
