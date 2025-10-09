using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.context;
using AliMartinCv.DataLayer.DTos;
using AliMartinCv.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AliMartinCv.Core.Sevices.Services
{
    public class ParentServices : IParent
    {
        private readonly AliMartinCvContext _context;
        public ParentServices(AliMartinCvContext context)
        {
            _context = context;
        }

        public async Task<bool> CompleteProfile(StudentInformationViewModel studentInformation)
        {
            try
            {
                await _context.StudentsInformations.AddAsync(new StudentInformation()
                {
                    StudentId = studentInformation.StudentId,
                    DateOfBirth = studentInformation.DateOfBirth,
                    Gender = studentInformation.Gender,
                    FamilyStatus = studentInformation.FamilyStatus,
                    FamilyMemberCount = studentInformation.FamilyMemberCount,
                    SiblingsCount = studentInformation.SiblingsCount,
                    ChildOrder = studentInformation.ChildOrder,
                    FatherOccupation = studentInformation.FatherOccupation,
                    IsFatherEmployed = studentInformation.IsFatherEmployed,
                    MotherOccupation = studentInformation.MotherOccupation,
                    IsMotherEmployed = studentInformation.IsMotherEmployed,
                    HousingType = studentInformation.HousingType,
                    IsDivorced = studentInformation.IsDivorced,
                    ParentWithWhomLiving = studentInformation.ParentWithWhomLiving,
                    IsFatherDeceased = studentInformation.IsFatherDeceased,
                    FatherDeceasedDate = studentInformation.FatherDeceasedDate,
                    IsMotherDeceased = studentInformation.IsMotherDeceased,
                    MotherDeceasedDate = studentInformation.MotherDeceasedDate,
                    FamilyIncome = studentInformation.FamilyIncome,
                    HasFamilyHealthStatus = studentInformation.HasFamilyHealthStatus,
                    FamilyHealthStatus = studentInformation.FamilyHealthStatus,
                    HasStudentHealthStatus = studentInformation.HasStudentHealthStatus,
                    StudentHealthStatus = studentInformation.StudentHealthStatus,
                    HasPhysicalDisabilities = studentInformation.HasPhysicalDisabilities,
                    PhysicalDisabilities = studentInformation.PhysicalDisabilities,
                    HasHospitalizationHistory = studentInformation.HasHospitalizationHistory,
                    HasSurgicalHistory = studentInformation.HasSurgicalHistory,
                    SurgicalHistory = studentInformation.SurgicalHistory,
                    HasCommonDiseases = studentInformation.HasCommonDiseases,
                    CommonDiseases = studentInformation.CommonDiseases,
                    HasChronicDiseases = studentInformation.HasChronicDiseases,
                    ChronicDiseases = studentInformation.ChronicDiseases,
                    HasMentalDisorders = studentInformation.HasMentalDisorders,
                    MentalDisorders = studentInformation.MentalDisorders,
                    UsesPrescriptionMedications = studentInformation.UsesPrescriptionMedications,
                    Medications = studentInformation.Medications,
                    HasPsychologicalStatus = studentInformation.HasPsychologicalStatus,
                    PsychologicalStatus = studentInformation.PsychologicalStatus,
                    HasSocialInteraction = studentInformation.HasSocialInteraction,
                    SocialInteraction = studentInformation.SocialInteraction,
                    HasSocialSupport = studentInformation.HasSocialSupport,
                    SocialSupport = studentInformation.SocialSupport,
                    HasSocialProblems = studentInformation.HasSocialProblems,
                    SocialProblems = studentInformation.SocialProblems,
                    HasAcademicHistory = studentInformation.HasAcademicHistory,
                    AcademicHistory = studentInformation.AcademicHistory,
                    HasRepeatedGrades = studentInformation.HasRepeatedGrades,
                    HasLateArrivals = studentInformation.HasLateArrivals,
                    HasAcceleratedLearning = studentInformation.HasAcceleratedLearning,
                    HasSexualMaturity = studentInformation.HasSexualMaturity,
                    SexualMaturityStatus = studentInformation.SexualMaturityStatus,
                    HasEducationalResources = studentInformation.HasEducationalResources,
                    EducationalResources = studentInformation.EducationalResources,
                    HasCognitiveAbilities = studentInformation.HasCognitiveAbilities,
                    CognitiveAbilities = studentInformation.CognitiveAbilities,
                    HasAccessToTechnology = studentInformation.HasAccessToTechnology,
                    AccessToTechnology = studentInformation.AccessToTechnology,
                    HasTechnologyUsageHours = studentInformation.HasTechnologyUsageHours,
                    TechnologyUsageHours = studentInformation.TechnologyUsageHours,
                    HasPastSocialOrLegalProblems = studentInformation.HasPastSocialOrLegalProblems,
                    PastSocialOrLegalProblems = studentInformation.PastSocialOrLegalProblems,
                    IsCompeleted = true 
                });

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> CreateParent(List<Student> students)
        {
        //   var parents =  await _context.Parents.ToListAsync();
        //   foreach (var parent in parents)
        //   {
        //       parent.Password = PasswordHasher.HashPassword(parent.Password);
        //       _context.Update(parent);
        //      await _context.SaveChangesAsync();
        //   }
        //    var x = await _context.Parents.CountAsync();
            return true;
        }

        public async Task<Parent> GetParentByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(userName));
            }

            return await _context.Parents
                .SingleOrDefaultAsync(p => p.UserName == userName);
        }


        public async Task<bool> IsExistsParent(string UserName)
        {
            return await _context.Parents.AnyAsync(p => p.UserName == UserName);
        }

        public async Task<bool> IsProfileCompleted(Guid studentId)
        {
            var info = await _context.StudentsInformations
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.StudentId == studentId);

           
            if (info is null) return false;

            return info.IsCompeleted; 
        }
    }
}
