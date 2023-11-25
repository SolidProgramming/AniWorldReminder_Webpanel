﻿using System.ComponentModel.DataAnnotations;

namespace AniWorldReminder_Webpanel.Models
{
    public class ReminderModel
    {
        [Required(ErrorMessage = "Bitte Serien Namen eingeben")]
        public string SeriesName { get; set; }

        public List<string> Languages { get; set; } = new ();

    }
}
