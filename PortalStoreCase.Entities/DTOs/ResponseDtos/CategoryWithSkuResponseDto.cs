using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Entities.DTOs.ResponseDtos
{
    public class CategoryWithSkuResponseDto:CategoryResponseDto
    {
        public List<SkuResponseDto> SkuResponseDtos { get; set; }
    }
}
