using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace template_identifier.Common.Models
{
    public class PagingParameterModel  
    {  
        public int MaxPageSize { get; set; } = 20;  
  
        public int PageNumber { get; set; } = 1;  
  
        private int _pageSize { get; set; } = 10;  
  
        public int PageSize  
        {  
  
            get { return _pageSize; }  
            set  
            {  
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;  
            }  
        }  
    }
}