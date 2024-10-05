﻿namespace Biblioteca.Application.Queries.Response.Author
{
    public class FindAuthorResponse
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
