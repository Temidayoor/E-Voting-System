using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Voting_System.Areas.Identity.Data;

// Add profile data for application users by adding properties to the E_Voting_SystemUser class

public class E_Voting_SystemUser : IdentityUser
{
    [Required]
    public string VoterId { get; set; }

    public string Name { get; set; }

    [Required]

    [Range(18, int.MaxValue, 
        ErrorMessage = "You must be at least 18 years old to register")]
    public int Age { get; set; }

    public string Mobile { get; set; }

    [Required]
    public string State { get; set; }

    public string Address { get; set; }

    //public IFormFile ProfileImage { get; set; }
}

