using System.Collections.Generic;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Data
{
    public static class MockData{
        public static List<UserViewModel> User = new List<UserViewModel>{};

        public static List<GroupViewModel> Groups =  new List<GroupViewModel>{};

        public static List<GiftViewModel> Gift = new List<GiftViewModel>{};
    }
}