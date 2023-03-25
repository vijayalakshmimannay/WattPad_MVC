using Microsoft.AspNetCore.Http;
using System;

namespace WattPad.Models
{
    public class BlogModel    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Content { get; set; }
        public IFormFile ImagePath { get; set; }

        
    }
}
