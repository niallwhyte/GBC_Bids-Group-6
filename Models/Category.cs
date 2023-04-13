using System;
using System.ComponentModel.DataAnnotations;

public class Category
{
	public int Id { get; set; }
	[Required (ErrorMessage = "Please select a category name")]
	public string Name { get; set; }
}
