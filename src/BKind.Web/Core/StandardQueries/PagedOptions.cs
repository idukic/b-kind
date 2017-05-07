﻿using System;
using System.Linq.Expressions;
using BKind.Web.Model;

namespace BKind.Web.Core.StandardQueries
{
    public class PagedOptions<T> where T:Entity
    {
        public PagedOptions(int? page = 1, int? pageSize = 10, Expression<Func<T, object>> orderBy = null, bool ascending = true)
        {
            Page = page ?? 1;
            PageSize = pageSize ?? 100;
            OrderBy = orderBy ?? (x => x.Id);
            Ascending = ascending;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public Expression<Func<T, object>> OrderBy { get; set; }
        public bool Ascending { get; set; }
    }
}