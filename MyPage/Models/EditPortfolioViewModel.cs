namespace MyPage.Models
{
    public class EditPortfolioViewModel
    {       
        public int PortfolioID { get; set; }
        public string? PortfolioName { get; set; }
        public  string? Description { get; set; }
        public string? ProjectUrl { get; set; }
        public IFormFile? ImageUrl1 { get; set; } 
        public IFormFile? ImageUrl2 { get; set; } 
        public IFormFile? ImageUrl3 { get; set; } 
        public IFormFile? ImageUrl4 { get; set; }   
        public string? ExistingImage1 { get; set; }
        public string? ExistingImage2 { get; set; }
        public string? ExistingImage3 { get; set; }
        public string? ExistingImage4 { get; set; }
    }
}
