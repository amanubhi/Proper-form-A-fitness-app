using System.ComponentModel.DataAnnotations;

public class SignupCheck
{
  [Key]
  public bool emailExists { get; set; }
  public bool usernameExists { get; set; }

}