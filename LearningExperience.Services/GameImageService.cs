using System.Collections.Generic;


namespace LearningExperience.Services
{
    public class GameImageService
    {
        private readonly IPatientRepository _patientRepository;

        public ImageService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public void RegisterImage()
        {

        }
    }
}