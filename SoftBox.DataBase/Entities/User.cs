﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBox.DataBase.Entities;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public string? Password { get; set; }
    public string? Phone { get; set; }

    //Organization
    public Guid OrganizationId { get; set; }
    public string? Title { get; set; }
    public string? LegalName { get; set; }

    public long TypeUserId { get; set; }
}
