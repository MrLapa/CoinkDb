using System.ComponentModel.DataAnnotations;

namespace CoinkApi.DTOs
{
    public class UserRequestQueryDto
    {
        public int? Id { get; set; }        
        
        [StringLength(50, MinimumLength = 0)]
        public string Name { get; set; }
        
        [StringLength(50, MinimumLength = 0)]
        public string Phone { get; set; }

        [StringLength(50, MinimumLength = 0)]
        public string Address { get; set; }        
        public int? CityId { get; set; }
    }
}
