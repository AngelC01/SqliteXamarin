using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlitePrueba.Models
{
    [Table("user")]
    public class User   

    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public String Name { get; set; }
        [MaxLength(70)]
        public String LastName { get; set; }
        
        public byte[] ImageProfile { get; set; }

    }
}
