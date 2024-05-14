using AutoMapperProject;
using Entities;
using Microsoft.AspNetCore.Http;

namespace Dtos
{
    public class PlanTypeDto
    {
        public int? Id { get; set; }
        public string PlanName { get; set; }
        public string PlanDescription { get; set; }
        public PlanTypeEnum PlanType { get; set; }
        public PlanStatusEnum PlanStatus { get; set; }
        public Tag[] Tags { get; set; }
        //public IFormFile Logo { get; set; }
        public object PlanTime { get; set; }
        //public int? Gender { get; set; }
        //public int? Weight { get; set; }
        //public int? Place { get; set; }
        //public int? Level { get; set; }
        //public int State { get; set; }
        public WeekType[] Weeks { get; set; }
    }


    public class Tag
    {
        public int? Id { get; set; }
        public string Text { get; set; }
    }

    public class WeekType
    {
        public DayType[] Days { get; set; }
    }

    public class DayType
    {
        public string DayName { get; set; }
        public string DayDescription { get; set; }
        public bool IsRest { get; set; }
        public int? DayLongTime { get; set; }
        public ExerciseMasterType[] Exercises { get; set; }
    }

    public class ExerciseMasterType
    {
        public int? Type { get; set; }
        public ExerciseType Body { get; set; }
    }

    public class ExerciseType
    {
        public int? Id { get; set; }
        public int? ActionId { get; set; }
        public int? ActionType { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDescription { get; set; }
        public int? ExerciseRestType { get; set; }
        public int? ExerciseRestTime { get; set; }
        public bool? ExerciseSetType { get; set; }
        public SetType[] ExerciseSets { get; set; }
    }          
    public class SetType
    {
        public int? Id { get; set; }
        public int? Value { get; set; }
        public int? Type { get; set; }
    }

    public class CircuitType
    {
        public int? Id { get; set; }
        public int? ActionId { get; set; }
        public int? ActionType { get; set; }
        public string CircuitName { get; set; }
        public string CircuitDescription { get; set; }
        public int? CircuitRestType { get; set; }
        public int? CircuitRestTime { get; set; }
        public ExerciseType[] CircuitExercises { get; set; }
    }
}
