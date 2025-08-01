﻿using Microsoft.AspNetCore.Identity;

namespace RestaurantWebApplication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order>? Orders { get; set; }
    }
}
