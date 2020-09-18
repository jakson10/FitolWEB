using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebUI.Models
{
    public class AssignMovementModel
    {
        public int MovementId { get; set; }
        public string MovementName { get; set; }
        public bool Exists { get; set; } //bu kategori varmı yokmu ?
    }
}
