namespace GoGreenApi.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Cep { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
    }
}