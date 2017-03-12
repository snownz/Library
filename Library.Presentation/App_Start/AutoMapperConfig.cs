using AutoMapper;
using Library.Presentation.App_Start.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Presentation.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<EntityToModelProfile>();
                x.AddProfile<ViewModelToEntityProfile>();
                x.AddProfile<EntitySelectListItemProfile>();
            });
        }
    }
}