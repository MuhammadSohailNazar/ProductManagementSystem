using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementSystem.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public class Product
        {
            public const string GetAll = Base + "/products";
            public const string Create = Base + "/products";
            public const string Get = Base + "/products/{productId}";
            public const string Update = Base + "/products/{productId}";
            public const string Delete = Base + "/products/{productId}";
        }

        public class Category
        {
            public const string GetAll = Base + "/categories";
            public const string Create = Base + "/categories";
            public const string Get = Base + "/categories/{categoryId}";
            public const string Update = Base + "/categories/{categoryId}";
            public const string Delete = Base + "/categories/{categoryId}";
        }

        public class Brand
        {
            public const string GetAll = Base + "/Brands";
            public const string Create = Base + "/Brands";
            public const string Get = Base + "/Brands/{brandId}";
            public const string Update = Base + "/Brands/{brandId}";
            public const string Delete = Base + "/Brands/{brandId}";
        }
        public class ProductVariant
        {
            public const string GetAll = Base + "/ProductVariants";
            public const string Create = Base + "/ProductVariants";
            public const string Get = Base + "/ProductVariants/{productVariantId}";
            public const string Update = Base + "/ProductVariants/{productVariantId}";
            public const string Delete = Base + "/ProductVariants/{productVariantId}";
        }
    }
}
