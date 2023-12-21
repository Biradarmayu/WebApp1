namespace WebApp.Models
{
    public class TeacherAddress
    {
        
            public int TeacherAddressId { get; set; }
            public string Street { get; set; }
            public string City { get; set; }

            // Foreign key property for the one-to-one relationship
            public int TeacherId { get; set; }

            // Navigation property for one-to-one relationship
            public virtual Teacher Teacher { get; set; }
        
    }
}
