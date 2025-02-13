﻿using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Infrastructure.EFCore;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagement.Infrastructure.EFCore;

namespace InventoryManagement.Infrastructure.EFCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly ShopContext shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly AccountContext _accountContext;

        public InventoryRepository(InventoryContext inventoryContext, ShopContext shopContext,
            AccountContext accountContext) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
            this.shopContext = shopContext;
            _accountContext = accountContext;
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryContext.Inventory.Select(x => new EditInventory
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice

            }).FirstOrDefault(x => x.Id == id);
        }

        public Inventory GetBy(long productId)
        {
            return _inventoryContext.Inventory.FirstOrDefault(x => x.ProductId == productId);
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var product = shopContext.Products.Select(x => new {x.Id, x.Name}).ToList();
            var query = _inventoryContext.Inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                InStock = x.InStock,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                CurrentCount = x.CalculateInventoryStock(),
                CreationDate = x.CreationDate.ToFarsi()
            });


            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);


            if (searchModel.InStock)
                query = query.Where(x => !x.InStock);


            var inventory = query.OrderByDescending(x => x.Id).ToList();

            inventory.ForEach(item => { item.Product = product.FirstOrDefault(x => x.Id == item.ProductId)?.Name; });
            return inventory;
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            var account = _accountContext.Accounts.Select(x => new {x.Id, x.Fullname}).ToList();
            var inventory = _inventoryContext.Inventory.FirstOrDefault(x => x.Id == inventoryId);
            var operations = inventory.Operations.Select(x => new InventoryOperationViewModel
            {
                Id = x.Id,
                Count = x.Count,
                Description = x.Description,
                CurrentCount = x.CurrentCount,
                Operation = x.Operation,
                OperationDate = x.OperationDate.ToFarsi(),
                OrderId = x.OrderId,
                OperatorId = x.OperatorId
            }).OrderByDescending(x => x.Id).ToList();

            foreach (var operation in operations)
                operation.Operator = account.FirstOrDefault(x => x.Id == operation.OperatorId)?.Fullname;

            return operations;
        }
    }
}
