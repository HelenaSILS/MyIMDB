using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // utilizado para o Required e o Range

namespace MyIMDB.ViewModels
{
    public class MovieCreateViewModel
    {
        [Required(ErrorMessage ="Rank is required")]
        [Range(1,10, ErrorMessage ="Rank should be in between {1} and {2}")]
        public int Rank { get; set; }
        
        [Required(ErrorMessage ="Title of the movie is required")]
        [MaxLength(100, ErrorMessage ="Title can't be greater than {1} characters")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Release year is required")]
        [Range(1900, 2021, ErrorMessage ="Year of release should be in between {1} and {2}")]
        public int Year { get; set; }

        [Required(ErrorMessage ="The storyline of the movie is required")]
        [MaxLength(200, ErrorMessage = "StoryLine can't be greater than {1}")]
        public string StoryLine { get; set; }

    }
}
