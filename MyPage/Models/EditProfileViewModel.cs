namespace MyPage.Models
{
    public class EditProfileViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Title { get; set; }
        public IFormFile? Image { get; set; } // Dosya yükleme için
        public string? ImageUrl { get; set; } // Mevcut resmi göstermek için
    }
}
