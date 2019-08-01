using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyFootbal.Models.User
{
    /// <summary>
    /// This class describes all the properties of any user.
    /// </summary>
    [Table("Registration")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        // First name of user
        [Required]
        [Column("FirstName", TypeName = "nvarchar(50)")]
        public string FName { get; set; }

        // Last name of user
        [Required]
        [Column("LastName", TypeName = "nvarchar(50)")]
        public string LName { get; set; }

        // Email of user
        [Required]
        [Column("Email", TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        // Phone number of user
        [Column("Phone", TypeName = "nvarchar(15)")]
        public string Phone { get; set; }

        // Gender of user. Only can be Male or female
        [Column("Gender")]
        public string Gender { get; set; }

        // Birthday of user
        [Required]
        [DataType(DataType.Date)]
        [Column("Birtday")]
        public DateTime Birthday { get; set; }

        // Password of user
        [Required]
        [Column("Password", TypeName = "nvarchar(50)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
