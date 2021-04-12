using System.ComponentModel.DataAnnotations;

namespace SecretSanta.Web.ViewModels{
    public class GroupViewModel{
        public int Id { get; set; }

        [Required]
        [Display (GroupName = "Group Name")]
        public string GroupName{get; set;} = "";

        public string Group {get => $"{GroupName}";}
    }
}