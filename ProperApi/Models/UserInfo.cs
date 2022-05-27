using System.ComponentModel.DataAnnotations;

public class UserInfo
{
[Key]
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool Verified { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public int Weight { get; set; }
    public int GoalWeight { get; set; }
    public int Height { get; set; }
    public string Birthday { get; set; }
    public string Token { get; set; }

}