using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeamPlayer.Models;

    public class Player
    {
        public int PlayerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }

        public string? TeamName { get; set; }

        [ForeignKey("TeamName")]
        //It is an acyuall object of type Team
        public Team? Team { get; set; }
    }
