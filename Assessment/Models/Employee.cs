using SQLite;

namespace Assessment.Models
{
    public class Employee : ImageDetails
    {
        #region PROPERTIES

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Phone { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string EmployeeId { get; set; }

        [MaxLength(255)]
        public string Department { get; set; }

        #endregion
    }
}