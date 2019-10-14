using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListApplication.Data.DbModel
{
    public class User:IBaseDbEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        public string EmailAdress { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public DateTime CreatedDate { get; set; }=DateTime.Now;

        public int Status { get; set; } = 1;
    }
}
