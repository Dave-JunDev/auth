using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Model;

[Table("user")]
public class User
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Column("username")]
    public string Username { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("phone")]
    public string FirstName { get; set; }
    [Column("lastname")]
    public string LastName { get; set; }
    [Column("role")]
    public int Role { get; set; }
    [Column("is_active")]
    public bool IsActive { get; set; }
    [Column("birthdate")]
    public DateTime dateOfBirth { get; set; }
}