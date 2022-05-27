using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



    public class NutEntries
    {
        [Key]
        public int ID { get; set; }
        
        public string ItemName { get; set; }

        public int Calories { get; set; }

        public int Fat { get; set; }

        public int Sugar { get; set; }

        public int Carbs { get; set; }

        public int Protein { get; set; }

    }
