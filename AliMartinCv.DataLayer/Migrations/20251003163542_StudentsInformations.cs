using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AliMartinCv.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class StudentsInformations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentsInformations",
                columns: table => new
                {
                    StudentInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyMemberCount = table.Column<int>(type: "int", nullable: false),
                    SiblingsCount = table.Column<int>(type: "int", nullable: false),
                    ChildOrder = table.Column<int>(type: "int", nullable: false),
                    FatherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFatherEmployed = table.Column<bool>(type: "bit", nullable: false),
                    MotherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMotherEmployed = table.Column<bool>(type: "bit", nullable: false),
                    HousingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDivorced = table.Column<bool>(type: "bit", nullable: false),
                    ParentWithWhomLiving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFatherDeceased = table.Column<bool>(type: "bit", nullable: false),
                    FatherDeceasedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsMotherDeceased = table.Column<bool>(type: "bit", nullable: false),
                    MotherDeceasedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FamilyIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HasFamilyHealthStatus = table.Column<bool>(type: "bit", nullable: false),
                    FamilyHealthStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasStudentHealthStatus = table.Column<bool>(type: "bit", nullable: false),
                    StudentHealthStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasPhysicalDisabilities = table.Column<bool>(type: "bit", nullable: false),
                    PhysicalDisabilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasHospitalizationHistory = table.Column<bool>(type: "bit", nullable: false),
                    HasSurgicalHistory = table.Column<bool>(type: "bit", nullable: false),
                    SurgicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasCommonDiseases = table.Column<bool>(type: "bit", nullable: false),
                    CommonDiseases = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasChronicDiseases = table.Column<bool>(type: "bit", nullable: false),
                    ChronicDiseases = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasMentalDisorders = table.Column<bool>(type: "bit", nullable: false),
                    MentalDisorders = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsesPrescriptionMedications = table.Column<bool>(type: "bit", nullable: false),
                    Medications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasPsychologicalStatus = table.Column<bool>(type: "bit", nullable: false),
                    PsychologicalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasSocialInteraction = table.Column<bool>(type: "bit", nullable: false),
                    SocialInteraction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasSocialSupport = table.Column<bool>(type: "bit", nullable: false),
                    SocialSupport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasSocialProblems = table.Column<bool>(type: "bit", nullable: false),
                    SocialProblems = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasAcademicHistory = table.Column<bool>(type: "bit", nullable: false),
                    AcademicHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasRepeatedGrades = table.Column<bool>(type: "bit", nullable: false),
                    HasLateArrivals = table.Column<bool>(type: "bit", nullable: false),
                    HasAcceleratedLearning = table.Column<bool>(type: "bit", nullable: false),
                    HasSexualMaturity = table.Column<bool>(type: "bit", nullable: false),
                    SexualMaturityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasEducationalResources = table.Column<bool>(type: "bit", nullable: false),
                    EducationalResources = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasCognitiveAbilities = table.Column<bool>(type: "bit", nullable: false),
                    CognitiveAbilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasAccessToTechnology = table.Column<bool>(type: "bit", nullable: false),
                    AccessToTechnology = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasTechnologyUsageHours = table.Column<bool>(type: "bit", nullable: false),
                    TechnologyUsageHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasPastSocialOrLegalProblems = table.Column<bool>(type: "bit", nullable: false),
                    PastSocialOrLegalProblems = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsInformations", x => x.StudentInformationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsInformations");
        }
    }
}
