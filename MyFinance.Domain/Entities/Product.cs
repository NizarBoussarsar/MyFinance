using MyFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("EspritProducts")]
public class Product
{
    public int ProductId { get; set; }

    [DataType(DataType.MultilineText)]
    public string Description { get; set; }

    [Required(ErrorMessage = "Name Required")]
    [StringLength(25, ErrorMessage = "Must be less than 25 characters")]
    [MaxLength(50)]
    public string Name { get; set; }

    [Range(0, double.MaxValue)]
    [DataType(DataType.Currency)]
    public double Price { get; set; }

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    [DataType(DataType.ImageUrl), Display(Name = "Image")]
    public string ImageName { get; set; }

    [Display(Name = "Production Date")]
    [DataType(DataType.DateTime)]
    public DateTime DateProd { get; set; }

    //foreign Key properties
    public int? CategoryId { get; set; }

    //navigation properties
    [ForeignKey("CategoryId ")]      //useless in this case   
    public virtual Category Category { get; set; }
    public virtual ICollection<Provider> Providers { get; set; }

}
