namespace SecretSanta.Api.Dto
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public static User? ToDto(Data.User? user)
        {
            if (user is null) return null;
            return new User
            {
                FirstName = user.FirstName,
                Id = user.UserId,
                LastName = user.LastName
            };
        }

        public static Data.User? FromDto(User? user)
        {
            if (user is null) return null;
            return new Data.User
            {
                UserId = user.Id,
                FirstName = user.FirstName ?? "",
                LastName = user.LastName ?? ""
            };
        }
    }
}
