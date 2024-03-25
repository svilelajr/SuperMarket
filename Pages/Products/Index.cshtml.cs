using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Data;
using SuperMarket.Models;

namespace SuperMarket.Pages_Products
{
    public class IndexModel : PageModel
    {
        private readonly SuperMarket.Data.ApplicationDbContext _context;

        public IndexModel(SuperMarket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                Products = await _context.Products.ToListAsync();
            }
        }

         public IActionResult OnGetGeneratePdf()
        {
            var products = _context.Products.ToList();
            var pdfStream = GeneratePdfStream(products);
            return File(pdfStream, "application/pdf", "lista_produtos.pdf");
        }

        public MemoryStream GeneratePdfStream(List<Product> Products)
        {
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = new PdfWriter(ms);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            Paragraph header = new Paragraph("Lista de Produtos");
            header.SetFontSize(20);
            document.Add(header);

            foreach (var product in Products)
            {
                document.Add(new Paragraph($"{product.Id}: {product.Name} - {product.Price}"));
            }

            document.Close();
            ms.Position = 0; // Reset the position to the beginning of the stream
            return ms;
        }
       
    }
}
