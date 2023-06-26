using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Sale
    {
        public Sale()
        {

        }
        public Sale(DateTime date, Product product, Customer customer, Store store)
        {

        }

        [Key]
        public int SaleID { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }


        public int ProductID { get; set; }

        [Required]
        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }

        public int CustomerID { get; set; }

        [ForeignKey(nameof(CustomerID))]
        public Customer Customer { get; set; }

        public int StoreID { get; set; }

        [Required]
        [ForeignKey(nameof(StoreID))]
        public Store Store { get; set; }
    }
}
