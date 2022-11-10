using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pilarski_David_Midterm.Data;
using Pilarski_David_Midterm.Models;

namespace Pilarski_David_Midterm.Pages
{
    public class StockInformationModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private List<Product> Products { get; set; }

        public double TotalStockValue
        {
            get
            {
                return Math.Round(Products.Sum(e => e.Quantity * e.SellPrice), 2);
            }
        }

        public double AverageProductPrice
        {
            get
            {
                if (Products.Count == 0) return 0;
                return Math.Round(Products.Average(e => e.SellPrice), 2);
            }
        }

        public double TotalStockProfit
        {
            get
            {
                return Math.Round(TotalStockValue - Products.Sum(e => e.Quantity * e.BuyPrice), 2);
            }
        }

        public StockInformationModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Products = _context.Products.ToList();
        }
    }
}
