﻿using System.ComponentModel.DataAnnotations;

namespace ErpApi.Models.Timesheet;

public class ProjectsJob : Timesheet
{
    [Key]
    public int Id { get; set; }

    public bool? Active { get; set; }

    public int? ProjectId { get; set; }

    //public int? JobCodeId { get; set; }

    [MaxLength(20)]
    public string ShortCode { get; set; }

    [MaxLength(255)]
    public string Name { get; set; }
}
