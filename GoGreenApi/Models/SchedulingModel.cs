namespace GoGreenApi.Models
{
    public class SchedulingModel
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCompany { get; set; }
        public string Product { get; set; }
        public string StatusScheduling { get; set; }
        public DateTime dtCreated { get; set; }
        public string Category { get; set; }
        public string DescriptionProduct { get; set; }  

    }
}
