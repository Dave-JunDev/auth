using System.Text;

namespace Auth.DTO;

public class UserDTO
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime dateOfBirth { get; set; }
    private int Role { get; set; } = 1;

    public void EncrytPassword()
    {
        Password = Convert.ToBase64String(Encoding.Default.GetBytes(Password));
    }
}