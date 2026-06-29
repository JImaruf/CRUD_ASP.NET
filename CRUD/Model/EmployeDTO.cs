namespace CRUD.Model
{
    public class EmployeDTOInput
    {
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
    }

    public class EmployeDTOOutput
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
    }
}
