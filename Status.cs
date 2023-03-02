using System;
using System.ComponentModel.DataAnnotations;
namespace TodolistNg
{
	public class Status
	{
		public int Id { get; set; }
		[StringLength(200)]
		public string StatusOption { get; set; } = string.Empty;
	}
}

