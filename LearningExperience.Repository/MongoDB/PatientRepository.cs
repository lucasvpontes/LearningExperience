using LearningExperience.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningExperience.Services
{
    public class PatientRepository
    {

        public PatientRepository()
        {
 
        }

        public Patient Create(Patient patient)
        {
            //BaseCollection.Insert(book);
            return patient;
        }

        public void Update(Patient patient)
        {
            try
            {
                var ub = new UpdateBuilder<Patient>();
                ub.Set(u => u, patient);
                ub.Set(f => f.LastUpdate, DateTime.Now);
            } 
            catch(Exception e)
            {
                throw new InvalidOperationException("Patient cannot be updated. " + patient.Id, e);
            }
        }
    }
}
