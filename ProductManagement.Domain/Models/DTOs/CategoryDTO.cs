﻿namespace ProductManagementDomain.Models.DTOs
{
    public class CategoryDTO 
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;

    }
}
