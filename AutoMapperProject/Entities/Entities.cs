using System.ComponentModel.DataAnnotations;

namespace Entities
{
    #region BaseEntities
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifidAt { get; set; }
        public bool IsDeleted { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<Guid>
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }
    }
    #endregion

    public class Media : BaseEntity
    {
        public MediaTypeEnum MediaType { get; set; }
        public string Uri { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public virtual List<Movement> Movements { get; set; }
    }
    public class Plan : BaseEntity<int>
    {
        public PlanTypeEnum PlanType { get; set; }
        public PlanStatusEnum PlanStatus { get; set; }
        public string? Name { get; set; }
        //public Guid? CoachId { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }

        public virtual UserProfile? UserProfile { get; set; }
        public virtual List<Workout> Workouts { get; set; }
        public virtual List<PackageSubscribtion> PackageSubscriptions { get; set; }
        public virtual List<PlanTag> PlanTags { get; set; }
        //public virtual List<Tag> Tags222 { get; set; }
    }
    public class UserProfile : BaseEntity
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public GenderEnum? Gender { get; set; }
        public byte[]? Image { get; set; }

        public virtual List<Plan> Plans { get; set; }
        public virtual List<PackageSubscribtion> PackageSubscriptions { get; set; }
        public virtual List<UserProfileSocialMedia> UserProfileSocialMedias { get; set; }
    }
    public class UserProfileSocialMedia : BaseEntity
    {
        public Guid? UserProfileId { get; set; }
        public Guid? SocialMediaId { get; set; }
        public string Description { get; set; }


        public virtual UserProfile? UserProfile { get; set; }
        public virtual SocialMedia? SocialMedia { get; set; }
    }
    public class Workout : BaseEntity
    {
        public Guid? PlanId { get; set; }
        public int Day { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public virtual Plan? Plan { get; set; }
        public virtual List<WorkoutDetail> WorkoutDetails { get; set; }
    }
    public class WorkoutDetail : BaseEntity
    {
        public Guid? WorkoutId { get; set; }
        public Guid? MovementId { get; set; }
        public bool IsCircuit { get; set; }
        public int Set { get; set; }
        public int Repeat { get; set; }
        public string? Note { get; set; }
        public int? RestTime { get; set; }
        public int DurationTime { get; set; }
        public bool IsDone { get; set; }

        public virtual Workout? Workout { get; set; }
        public virtual Movement? Movement { get; set; }
    }
    public class PackageSubscribtion : BaseEntity
    {
        public Guid? AtheleteId { get; set; }
        public Guid? PlanId { get; set; }
        public string SubscribtionDate { get; set; }
        public SubscribtionStatusEnum SubscribtionStatus { get; set; }
        public string PaymentReferenceNumber { get; set; }
        public string Description { get; set; }

        public virtual UserProfile? UserProfile { get; set; }
        public virtual Plan? Plan { get; set; }
    }
    public class PlanTag /*: BaseEntity*/
    {
        public int? PlanId { get; set; }
        public int? TagId { get; set; }

        public virtual Plan? Plan { get; set; }
        public virtual Tag? Tag { get; set; }
    }
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<MovementTag> MovementTags { get; set; }
        public virtual List<PlanTag> PlanTags { get; set; }
    }
    public class Movement : BaseEntity
    {
        public MovementTypeEnum MovementType { get; set; }
        public Guid? MediaId { get; set; }
        public string Name { get; set; }
        public byte[]? Image { get; set; }
        public string? VideoUrl { get; set; }
        public string? Description { get; set; }

        public virtual Media? Media { get; set; }
        public virtual List<WorkoutDetail> WorkoutDetails { get; set; }
        public virtual List<MovementTag> MovementTags { get; set; }
    }
    public class MovementTag : BaseEntity
    {
        public Guid? MovementId { get; set; }
        public Guid? TagId { get; set; }

        public virtual Movement? Movement { get; set; }
        public virtual Tag? Tag { get; set; }
    }
    public class SocialMedia : BaseEntity
    {
        public string Name { get; set; }
        public byte[]? Image { get; set; }
        public string Description { get; set; }


        public virtual List<UserProfileSocialMedia> UserProfileSocialMedias { get; set; }
    }

    #region Enums
    public enum PlanTypeEnum
    {
        [Display(Name = "General")]
        General = 0,
        [Display(Name = "VIP")]
        VIP = 1,
    }
    public enum PlanStatusEnum
    {
        [Display(Name = "Started")]
        Started = 0,
        [Display(Name = "InProgress")]
        InProgress = 1,
        [Display(Name = "Finished")]
        Finished = 2,
    }
    public enum GenderEnum
    {
        [Display(Name = "Female")]
        Femail = 0,
        [Display(Name = "Male")]
        Male = 1,
    }
    public enum MediaTypeEnum
    {
        [Display(Name = "Gif")]
        Gif = 0,
        [Display(Name = "Mp4")]
        Mp4 = 1,
    }
    public enum MovementTypeEnum
    {
        [Display(Name = "General")]
        General = 0,
        [Display(Name = "Exclusive")]
        Exclusive = 1,
    }
    public enum SetTypeEnum
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "SuperSet")]
        SuperSet = 1,
        [Display(Name = "TriSet")]
        TriSet = 2,
    }
    public enum SubscribtionStatusEnum
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Payed")]
        Payed = 1,
        [Display(Name = "NotPayed")]
        NotPayed = 2,
    }
    #endregion
}
