using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

  public class UserNut
  {
    [Key]
    public int ID { get; set; }

    public int UserID { get; set; }

    public int FoodID { get; set; }

    public DateTime DateAdded { get; set; }
  }

