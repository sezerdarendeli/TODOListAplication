using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListApplication.Data.DbModel
{
    public class ToDoTask:IBaseDbEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        public  int ToDoId { get; set; }

        public string TaskName { get; set; }

        public DateTime ExpireDateTime { get; set; }

        public  bool Completed { get; set; }

        public  string Description { get; set; }
        
        
    }
}
