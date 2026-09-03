using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Application.Features.CQRSDesignPattern.Result.MovieResults
{
    public class GetMovieQueryResult
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? CoverImageUrl { get; set; }
        public decimal rating { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? CreatedYear { get; set; }
        public bool Status { get; set; }
    }
}
}
