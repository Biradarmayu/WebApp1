namespace WebApp.Models
{
    public class Teacher
    { 
            public int TeacherId { get; set; }
            public string Name { get; set; }

            // Navigation property for one-to-one relationship
            public virtual TeacherAddress Address { get; set; }
        

    }
}
