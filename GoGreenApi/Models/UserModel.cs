namespace GoGreenApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }

        public string Senha { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Cep { get; set; }
    }
}

