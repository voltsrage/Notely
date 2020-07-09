﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotelyApp.Models
{
    public class Note
    {
        [Required]
        public Guid NoteID { get; set; }

        [Required(ErrorMessage ="Please enter the subject")]
        public string Subject { get; set; }

        public string Detail { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
