namespace SecretSanta.Api.Dto
{
    public class Gift
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? URL { get; set; }
        public int Priority { get; set; }
        public int UserId { get; set; }

        public static Gift? ToDto(Data.Gift? gift)
        {
            if (gift is null) return null;
            return new Gift
            {
                Title = gift.Title,
                Id = gift.Id,
                Description = gift.Description,
                URL = gift.URL,
                Priority = gift.Priority,
                UserId = gift.UserId
            };
        }

        public static Data.Gift? FromDto(Gift? gift)
        {
            if (gift is null) return null;
            return new Data.Gift
            {
                Title = gift.Title ?? "",
                Id = gift.Id,
                Description = gift.Description ?? "",
                URL = gift.URL ?? "",
                Priority = gift.Priority,
                UserId = gift.UserId
            };
        }
    }
}
