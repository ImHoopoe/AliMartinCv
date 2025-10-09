using System;

namespace AliMartinCv.DataLayer.Entities
{
    public class StudentInformation
    {
        public Guid StudentInformationId { get; set; }
        public Guid StudentId { get; set; }

        // دسته‌بندی خانواده
        public DateTime DateOfBirth { get; set; } // تاریخ تولد
        public string? Gender { get; set; } // جنسیت
        public string? FamilyStatus { get; set; } // وضعیت خانواده
        public int? FamilyMemberCount { get; set; } // تعداد اعضای خانواده
        public int? SiblingsCount { get; set; } // تعداد خواهران و برادران
        public int? ChildOrder { get; set; } // فرزند چندم خانواده
        public string? FatherOccupation { get; set; } // شغل پدر
        public bool? IsFatherEmployed { get; set; } // آیا پدر شاغل است؟
        public string? MotherOccupation { get; set; } // شغل مادر
        public bool? IsMotherEmployed { get; set; } // آیا مادر شاغل است؟
        public string? HousingType { get; set; } // نوع مسکن

        // وضعیت زندگی با والدین
        public bool? IsDivorced { get; set; } // آیا فرزند طلاق است؟
        public string? ParentWithWhomLiving { get; set; } // با کدام والد زندگی می‌کند

        // وضعیت فوت پدر یا مادر
        public bool? IsFatherDeceased { get; set; } // آیا پدر فوت کرده است؟
        public DateTime? FatherDeceasedDate { get; set; } // تاریخ فوت پدر
        public bool? IsMotherDeceased { get; set; } // آیا مادر فوت کرده است؟
        public DateTime? MotherDeceasedDate { get; set; } // تاریخ فوت مادر

        // دسته‌بندی وضعیت اقتصادی
        public decimal? FamilyIncome { get; set; } // سطح درآمد

        // دسته‌بندی وضعیت سلامت
        public bool? HasFamilyHealthStatus { get; set; }
        public string? FamilyHealthStatus { get; set; }
        public bool? HasStudentHealthStatus { get; set; }
        public string? StudentHealthStatus { get; set; }
        public bool? HasPhysicalDisabilities { get; set; }
        public string? PhysicalDisabilities { get; set; }
        public bool? HasHospitalizationHistory { get; set; }
        public bool? HasSurgicalHistory { get; set; }
        public string? SurgicalHistory { get; set; }

        // دسته‌بندی بیماری‌ها و داروها
        public bool? HasCommonDiseases { get; set; }
        public string? CommonDiseases { get; set; }
        public bool? HasChronicDiseases { get; set; }
        public string? ChronicDiseases { get; set; }
        public bool? HasMentalDisorders { get; set; }
        public string? MentalDisorders { get; set; }
        public bool? UsesPrescriptionMedications { get; set; }
        public string? Medications { get; set; }

        // وضعیت روانی و اجتماعی
        public bool? HasPsychologicalStatus { get; set; }
        public string? PsychologicalStatus { get; set; }
        public bool? HasSocialInteraction { get; set; }
        public string? SocialInteraction { get; set; }
        public bool? HasSocialSupport { get; set; }
        public string? SocialSupport { get; set; }
        public bool? HasSocialProblems { get; set; }
        public string? SocialProblems { get; set; }

        // وضعیت تحصیلی
        public bool? HasAcademicHistory { get; set; }
        public string? AcademicHistory { get; set; }
        public bool? HasRepeatedGrades { get; set; }
        public bool? HasLateArrivals { get; set; }
        public bool? HasAcceleratedLearning { get; set; }

        // بلوغ
        public bool? HasSexualMaturity { get; set; }
        public string? SexualMaturityStatus { get; set; }

        // منابع آموزشی
        public bool? HasEducationalResources { get; set; }
        public string? EducationalResources { get; set; }

        // توانایی‌های شناختی
        public bool? HasCognitiveAbilities { get; set; }
        public string? CognitiveAbilities { get; set; }

        // فناوری
        public bool? HasAccessToTechnology { get; set; }
        public string? AccessToTechnology { get; set; }
        public bool? HasTechnologyUsageHours { get; set; }
        public string? TechnologyUsageHours { get; set; }

        // مشکلات اجتماعی یا جنایی
        public bool? HasPastSocialOrLegalProblems { get; set; }
        public string? PastSocialOrLegalProblems { get; set; }

        // وضعیت تکمیل فرم
        public bool IsCompeleted { get; set; } = false;
    }
}
