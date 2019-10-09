using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace InciOneSoft.BLL.Helpers
{
    public class AutoMapperService : IAutoMapperService
    {
        public IMapper Mapper
        {
            get { return ObjectMapper.Mapper; }
        }

    }
}
