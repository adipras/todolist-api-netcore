using System;
using System.ComponentModel.DataAnnotations;

namespace TodolistNg
{
	public class Task
	{
		public int Id { get; set; }
		[StringLength(200)]
		public string TaskName { get; set; } = string.Empty;
		public string Status { get; set; } = string.Empty;

		public int TaskTypeId { get; set; }
		public TaskType? TaskType { get; set; }
	}
}

