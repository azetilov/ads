using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ads.Api.Database.Entities
{
    public class AdChannel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }
        
        [ForeignKey("Ad")]
        public long AdId { get; set; }
        public virtual Ad Ad { get; set; }
        
        [ForeignKey("Channel")]
        public long ChannelId { get; set; }
        public virtual Channel Channel { get; set; }
    }
}