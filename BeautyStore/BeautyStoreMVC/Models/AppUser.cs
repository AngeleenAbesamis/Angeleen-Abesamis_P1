using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BeautyStoreMVC.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(450)]
        public override string Id { get { return base.Id; } }
        [StringLength(255)]
        public string Name { get; set; }
        public Guid DeviceToken { get; set; }
    }
}
