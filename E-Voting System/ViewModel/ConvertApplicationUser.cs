using E_Voting_System.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace E_Voting_System.ViewModel
{
    public class ConvertApplicationUser
    {
        public string Id { get; set; }
        public string Email { get; set; }

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

        public List<ConvertApplicationUser> ApplicationUsers { get; set; }= new List<ConvertApplicationUser> ();

        public ConvertApplicationUser()
        {

        }

        public ConvertApplicationUser(List<E_Voting_SystemUser> users)
        {
            foreach (var user in users)
            {
                ApplicationUsers.Add(
                    new ConvertApplicationUser
                    {
                        //Id=user.Id,
                        Email = user.Email,
                        VoterId = user.VoterId,
                        Name = user.Name,
                        Age = user.Age,
                        Mobile = user.Mobile,
                        State = user.State,
                        Address = user.Address,

                    });

            }
        }
    }
}
