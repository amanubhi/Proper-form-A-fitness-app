using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserRoutines
{
  [Key]
  public int ID { get; set; }
  public string RtName { get; set; }
  public int RtNumber { get; set; }
  [ForeignKey("UserID")]
  public int UserID { get; set; }
}