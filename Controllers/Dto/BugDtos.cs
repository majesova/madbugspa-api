using System;
using System.ComponentModel.DataAnnotations;

namespace MadBugAPI.Controllers.Dtos
{
    /// <summary>
    /// This class is used for Post method in BugController
    /// </summary>
    public class BugRegisterDto
    {
        [MaxLength(500)]
        public string Body { get; set; }
        
        public bool IsFixed{ get; set; }
        /// <summary>
        /// Expected values 1,2,3
        /// </summary>
        /// <value>integer value</value>
        [Required]
        public int Severity { get; set; }
        public string StepsToReproduce { get; set; }

        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

    }
    public class BugResponseDto {
        public int Id { get; set; }
        public string Body { get; set; }
        public bool IsFixed{ get; set; }
        public int Severity { get; set; }
        public string StepsToReproduce { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
    }

    public class BugUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Body { get; set; }
        
        public bool IsFixed{ get; set; }
        /// <summary>
        /// Expected values 1,2,3
        /// </summary>
        /// <value>integer value</value>
        [Required]
        public int Severity { get; set; }
        public string StepsToReproduce { get; set; }

        [MaxLength(200)]
        [Required]
        public string Title { get; set; }
        public string UserId { get; set; }

    }

}