using System;
using System.ComponentModel.DataAnnotations;

    public class WeightHistory
    {
        [Key]
        public int ID { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public double WeightChange { get; set; }

        public double Weight { get; set; }
    }

