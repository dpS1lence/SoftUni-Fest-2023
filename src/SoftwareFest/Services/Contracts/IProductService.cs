﻿namespace SoftwareFest.Services.Contracts
{
    using System.Linq.Expressions;

    using SoftwareFest.Models;
    using SoftwareFest.Pagination.Contracts;
    using SoftwareFest.Pagination.Enums;
    using SoftwareFest.ViewModels;

    public interface IProductService
    {
        Task<IPage<ShowProductViewModel>> GetPagedProducts(int pageIndex = 1, int pageSize = 50,
            Expression<Func<Models.Product, bool>>? predicate = null,
            Expression<Func<Models.Product, object>>? orderBy = null,
            SortDirection sortDirection = SortDirection.Ascending);
        Task AddProduct(ProductViewModel model, string userId);

        Task<ProductViewModel> GetById(int id);
        Task Update(ProductViewModel model);

        Task Delete(int id);

        Task<bool> IsOwner(string userId, int productId);
    }
}
