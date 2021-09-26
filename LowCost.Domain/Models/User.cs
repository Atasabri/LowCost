using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using LowCost.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;

namespace LowCost.Domain.Models
{
    public class User : IdentityUser
    {
        public string FCM { get; set; }
        [Required]
        public Languages CurrentLangauge { get; set; } = Languages.EN;
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public double Balance { get; set; }
        public int? Zone_Id { get; set; }
        public int? Stock_Id { get; set; }


        [ForeignKey(nameof(Zone_Id))]
        public Zone Zone { get; set; }

        [ForeignKey(nameof(Stock_Id))]
        public Stock Stock { get; set; }


        public ICollection<Notification> Notifications { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<PaymentMethod> Payments { get; set; }

        public ICollection<Favorites> Favorites { get; set; }

        public ICollection<ProductFollowingUser> ProductFollowingUsers { get; set; }

        public ICollection<IdentityUserRole<string>> UserRoles { get; set; }
    }
}
