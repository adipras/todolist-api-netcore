using System;
using System.ComponentModel.DataAnnotations;

namespace TodolistNg
{
	public class TaskType
	{
		public int Id { get; set; }
		[StringLength(200)]
		public string TypeName { get; set; } = string.Empty;
	}
}