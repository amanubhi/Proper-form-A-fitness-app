using System.ComponentModel.DataAnnotations;

public class LoginCheck
{
  [Key]
  public bool Equal { get; set; }
  public string Token { get; set; }
  public int UserID { get; set; }


}