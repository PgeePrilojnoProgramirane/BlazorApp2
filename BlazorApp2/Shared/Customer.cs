using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared
{
   
        [Serializable]
        public class Customer
        {
            [Key]
            public Guid id { get; set; } // CAN USE AN INTEGER INSTEAD OF A GUID

            [Required]
            public string name { get; set; }

            [Required]
            public string address { get; set; }

            [Required]
            public string zip { get; set; }
        }
    }

