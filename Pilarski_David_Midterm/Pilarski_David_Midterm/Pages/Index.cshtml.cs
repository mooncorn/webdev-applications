﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pilarski_David_Midterm.Data;
using Pilarski_David_Midterm.Models;

namespace Pilarski_David_Midterm.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Product> Products { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Products = _context.Products.ToList();
        }
    }
}