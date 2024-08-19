namespace HumanResourcesAPI.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
    }
}
