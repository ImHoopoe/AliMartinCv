using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.DataLayer.Entities
{
    public class StudentInformation
    {
        public Guid StudentInformationId { get; set; }
        public Guid StudentId { get; set; }
        // دسته‌بندی خانواده
        public DateTime DateOfBirth { get; set; } // تاریخ تولد
        public string Gender { get; set; } // جنسیت
        public string FamilyStatus { get; set; } // وضعیت خانواده (طلاق، ازدواج مجدد، زندگی با پدر یا مادر، سرپرست قانونی)
        public int FamilyMemberCount { get; set; } // تعداد اعضای خانواده
        public int SiblingsCount { get; set; } // تعداد خواهران و برادران
        public int ChildOrder { get; set; } // فرزند چندم خانواده
        public string FatherOccupation { get; set; } // شغل پدر
        public bool IsFatherEmployed { get; set; } // آیا پدر شاغل است؟
        public string MotherOccupation { get; set; } // شغل مادر
        public bool IsMotherEmployed { get; set; } // آیا مادر شاغل است؟
        public string HousingType { get; set; } // نوع مسکن (خانه، آپارتمان، خوابگاه و...)

        // وضعیت زندگی با والدین
        public bool IsDivorced { get; set; } // آیا بچه فرزند طلاق است؟
        public string ParentWithWhomLiving { get; set; } // با کدام والد زندگی می‌کند (پدر یا مادر)

        // وضعیت فوت پدر یا مادر
        public bool IsFatherDeceased { get; set; } // آیا پدر فوت کرده است؟
        public DateTime? FatherDeceasedDate { get; set; } // تاریخ فوت پدر (در صورت موجود بودن)
        public bool IsMotherDeceased { get; set; } // آیا مادر فوت کرده است؟
        public DateTime? MotherDeceasedDate { get; set; } // تاریخ فوت مادر (در صورت موجود بودن)

        // دسته‌بندی وضعیت اقتصادی
        public decimal FamilyIncome { get; set; } // وضعیت اقتصادی خانواده (سطح درآمد)

        // دسته‌بندی وضعیت سلامت
        public bool HasFamilyHealthStatus { get; set; } // آیا وضعیت بیماری‌های خانواده موجود است؟
        public string FamilyHealthStatus { get; set; } // وضعیت بیماری‌های جسمی یا روانی در خانواده
        public bool HasStudentHealthStatus { get; set; } // آیا وضعیت بیماری‌های دانش‌آموز موجود است؟
        public string StudentHealthStatus { get; set; } // وضعیت بیماری‌های مزمن یا خاص دانش‌آموز
        public bool HasPhysicalDisabilities { get; set; } // آیا آسیب‌های جسمی یا اختلالات حرکتی وجود دارد؟
        public string PhysicalDisabilities { get; set; } // آسیب‌های جسمی یا اختلالات حرکتی
        public bool HasHospitalizationHistory { get; set; } // آیا سابقه بستری یا جراحی در بیمارستان وجود دارد؟
        public bool HasSurgicalHistory { get; set; } // آیا سابقه جراحی یا عمل‌های پزشکی وجود دارد؟
        public string SurgicalHistory { get; set; } // نوع جراحی‌ها یا عمل‌های پزشکی که دانش‌آموز تجربه کرده است (در صورت وجود)

        // دسته‌بندی بیماری‌ها و داروها
        public bool HasCommonDiseases { get; set; } // آیا بیماری‌های رایج وجود دارد؟
        public string CommonDiseases { get; set; } // بیماری‌های رایج (مانند سرماخوردگی، آنفلوآنزا، آلرژی‌ها)
        public bool HasChronicDiseases { get; set; } // آیا بیماری‌های مزمن وجود دارد؟
        public string ChronicDiseases { get; set; } // بیماری‌های مزمن (مانند دیابت، آسم، فشار خون بالا)
        public bool HasMentalDisorders { get; set; } // آیا اختلالات روانی وجود دارد؟
        public string MentalDisorders { get; set; } // اختلالات روانی (مانند اضطراب، افسردگی، ADHD)
        public bool UsesPrescriptionMedications { get; set; } // آیا دانش‌آموز داروهای تجویزی مصرف می‌کند؟
        public string Medications { get; set; } // داروهایی که دانش‌آموز مصرف می‌کند

        // دسته‌بندی وضعیت روانی و اجتماعی
        public bool HasPsychologicalStatus { get; set; } // آیا وضعیت روانی وجود دارد؟
        public string PsychologicalStatus { get; set; } // وضعیت ذهنی و روانی (اختلالات اضطرابی، افسردگی، اختلالات رفتاری)
        public bool HasSocialInteraction { get; set; } // آیا تعامل اجتماعی وجود دارد؟
        public string SocialInteraction { get; set; } // وضعیت اجتماعی و میزان تعامل با دوستان و همکلاسی‌ها
        public bool HasSocialSupport { get; set; } // آیا حمایت اجتماعی وجود دارد؟
        public string SocialSupport { get; set; } // میزان و نوع حمایت اجتماعی (پشتیبانی از طرف خانواده، دوستان، معلمان)
        public bool HasSocialProblems { get; set; } // آیا مشکلات اجتماعی وجود دارد؟
        public string SocialProblems { get; set; } // آسیب‌های اجتماعی مانند خشونت خانگی یا مشکلات اجتماعی

        // دسته‌بندی وضعیت تحصیلی
        public bool HasAcademicHistory { get; set; } // آیا تاریخچه تحصیلی موجود است؟
        public string AcademicHistory { get; set; } // وضعیت تحصیلی قبلی (نمرات، پیشرفت تحصیلی، افت تحصیلی)
        public bool HasRepeatedGrades { get; set; } // آیا دانش‌آموز سابقه تجدید سال یا افت تحصیلی دارد؟
        public bool HasLateArrivals { get; set; } // آیا دانش‌آموز دیر به مدرسه می‌آید؟
        public bool HasAcceleratedLearning { get; set; } // آیا دانش‌آموز جهش تحصیلی کرده است؟ (مثلاً درسی را زودتر از موعد گذرانده است)

        // دسته‌بندی وضعیت بلوغ
        public bool HasSexualMaturity { get; set; } // آیا دانش‌آموز وارد بلوغ جنسی شده است؟
        public string SexualMaturityStatus { get; set; } // وضعیت بلوغ جنسی دانش‌آموز (در صورت موجود بودن اطلاعات)

        // دسته‌بندی الگوهای خواب و دسترسی به منابع آموزشی
        public bool HasEducationalResources { get; set; } // آیا منابع آموزشی وجود دارد؟
        public string EducationalResources { get; set; } // میزان دسترسی به منابع آموزشی (کتاب، اینترنت، کلاس‌های خصوصی)

        // دسته‌بندی توانایی‌های شناختی
        public bool HasCognitiveAbilities { get; set; } // آیا توانایی‌های شناختی وجود دارد؟
        public string CognitiveAbilities { get; set; } // توانایی‌های شناختی (حل مسئله، توجه، حافظه و...)

        // دسته‌بندی دسترسی به فناوری و استفاده از آن
        public bool HasAccessToTechnology { get; set; } // آیا دسترسی به فناوری وجود دارد؟
        public string AccessToTechnology { get; set; } // میزان دسترسی به امکانات رفاهی مانند اینترنت یا وسایل الکترونیکی
        public bool HasTechnologyUsageHours { get; set; } // آیا ساعات استفاده از فناوری مشخص است؟
        public string TechnologyUsageHours { get; set; } // ساعات استفاده از فناوری (گوشی، کامپیوتر، کنسول و...)

        // دسته‌بندی مشکلات اجتماعی یا جنایی گذشته
        public bool HasPastSocialOrLegalProblems { get; set; } // آیا مشکلات اجتماعی یا جنایی گذشته وجود دارد؟
        public string PastSocialOrLegalProblems { get; set; } // تجارب گذشته از مشکلات اجتماعی یا جنایی (اگر وجود دارد)
        public bool IsCompeleted { get; set; } = false;
    }
}
