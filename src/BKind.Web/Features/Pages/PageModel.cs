﻿using BKind.Web.Features.Shared;
using BKind.Web.Model;

namespace BKind.Web.Features.Pages
{
    public class PageModel : ViewModelBase
    {
        public PageModel(Page page, User user)
        {
            Page = page;

            if (user != null && user.Is<Administrator>())
                CanEdit = true;
        }

        public Page Page { get; set; }

        public bool CanEdit { get; set; }
    }
}