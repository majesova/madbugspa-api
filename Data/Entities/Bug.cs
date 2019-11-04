using System;

namespace MadBugAPI.Data.Entities
{
    /// <summary>
    /// Class for bug management
    /// </summary>
    public class Bug
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public bool IsFixed{ get; set; }
        public Severity Severity { get; set; }
        public string StepsToReproduce { get; set; }
        public string Title { get; set; }
        //User relation
        public string UserId { get; set; } //Usuario que creó
        public AppUser User { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public string ModifiedById { get; set; }

        public AppUser ModifiedBy  { get; set; }
        
    }
    /// <summary>
    /// Severity Bug enumeration
    /// </summary>
    public enum Severity
    {
        NORMAL=1, 
        SEVERE=2, 
        CRITICAL=3
    }
}