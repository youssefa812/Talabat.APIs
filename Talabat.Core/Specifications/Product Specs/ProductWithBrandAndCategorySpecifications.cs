﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;

namespace Talabat.Core.Specifications.Product_Specs
{
	public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product>
	{
        public ProductWithBrandAndCategorySpecifications()
            : base() 
        {
            AddIncludes();
        }

        public ProductWithBrandAndCategorySpecifications(int id)
            : base(P => P.Id == id)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
			Includes.Add(P => P.Brand);
			Includes.Add(P => P.Category);
		}
    }
}
