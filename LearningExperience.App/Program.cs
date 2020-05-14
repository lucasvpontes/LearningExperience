using LearningExperience.Models;
using LearningExperience.Models.Enums;
using LearningExperience.Repository.MongoDB;
using LearningExperience.Services;

namespace LearningExperience.App
{
    class Program
    {
        public static void Method()
        {
            Patient patient = new Patient();
            patient.Name = "Alvaro Dias";
            patient.Age = 10;
            patient.ColorsIssue = ColorIssueStatus.No;

            PatientRepository patientRepository = new PatientRepository();
            PatientService patientService = new PatientService(patientRepository);
            patientService.CreatePatient(patient);
        }
        static void Main(string[] args)
        {
            Method();
        }
    }
}
