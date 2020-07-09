using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotelyApp.Models
{
    public class NotesViewModel
    {
        [Required]
        public int NoteID { get; set; }

        [Required]
        public string Subject { get; set; }

        public string Detail { get; set; }
    }
}
