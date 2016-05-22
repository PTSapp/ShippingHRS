namespace ShippingApp.Model
{
    public class User
    {
        public User() { }
        
        // This one makes sense as serving for a login OR a password
        public string CompanyCardUniqueId { get; set; }
        public string Password { get; set; }

        public string Names { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public bool HasAdminPrivileges { get; set; }
        /* Add whatever you need him to have
           
           EXAMPLE: You need to tie this employee to a Shift object

           public Shift WorkShift { get; set; }
        */
    }
}
