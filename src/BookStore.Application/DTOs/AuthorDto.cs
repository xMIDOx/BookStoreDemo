﻿namespace BookStore.Application.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Bio { get; set; }
    }

    public class CreateAuthorDto
    {

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Bio { get; set; }
    }

    public class UpdateAuthorDto : CreateAuthorDto
    {
        public int Id { get; set; }

    }
}
