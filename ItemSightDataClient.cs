﻿using System;
using System.Collections.Generic;
using System.Linq;
using ItemSightDataServiceClient.ItemSightDataService;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ItemSightDataServiceClient {
    public class ItemSightDataClient {
        readonly ItemSightDataContext _dataContext;

        public ItemSightDataClient(string uri) {
            if (string.IsNullOrEmpty(uri)) throw new ArgumentException("Value cannot be null or empty.", "uri");
            _dataContext = new ItemSightDataContext(new Uri(uri));
            //_dataContext.Format.UseJson();
        }

        public IQueryable<BizLocationEx> GetMasterRepositories() {
            return _dataContext.BizLocationInfos.Expand(x => x.BizLocation).Where(x => x.BizLocation.BizLocationTypeID == 2);
        }

        public IQueryable<OrderEx> GetOrders(int masterRepositoryId) {
            return _dataContext.OrderInfos.Expand(x => x.Order).Where(x => x.Order.ownerID == masterRepositoryId);
        }

        public IQueryable<OrderLineEx> GetOrderLineItems(Int64 orderID) {
            return _dataContext.OrderLineInfos.Expand(x => x.OrderLine).Expand(x => x.OrderLine.Product).Where(x => x.OrderLine.orderID == orderID);
        }

        public IQueryable<BizLocationEx> GetFactoryLocations() {
            return _dataContext.BizLocationInfos.Expand(x => x.BizLocation).Where(x => x.BizLocation.BizLocationTypeID == 3);
        }

        public IQueryable<BizLocationEx> GetDistribCenterLocations() {
            return _dataContext.BizLocationInfos.Expand(x => x.BizLocation).Where(x => x.BizLocation.BizLocationTypeID == 4);
        }

        public IQueryable<ReadPointEx> GetReadpointDevices(int locationID) {
            return _dataContext.ReadPointInfos.Expand(x => x.ReadPoint).Where(x => x.ReadPoint.bizLocationID == locationID);
        }

        public IQueryable<PackingEx> GetCartons() {
            return _dataContext.PackingInfos.Expand(x => x.Packing).Where(x => x.Packing.PackingTypeID == 2);
        }

        public IQueryable<PackingProduct> GetCartonProducts(Int64 cartonID) {
            return _dataContext.PackingProducts.Expand(x => x.Product).Where(x => x.Packing.ID == cartonID);
        }

        public IQueryable<PackingEx> GetCartonEpcItems(Int64 cartonID) {
            return _dataContext.PackingInfos.Expand(x => x.Packing).Expand(x => x.Packing.Product).Where(x => x.Packing.parentID == cartonID);
        }

        public IQueryable<PackingError> GetCartonErrors(Int64 cartonID) {
            return _dataContext.PackingErrors.Where(x => x.packingID == cartonID);
        }

        public IQueryable<PackingIssueEx> GetCartonIssues(Int64 cartonID) {
            return _dataContext.PackingIssueInfos.Where(x => x.PackingIssue.packingID == cartonID);
        }

        public IQueryable<PackingHistoryErrorEx> GetCartonErrorHistory(Int64 cartonID) {
            return _dataContext.PackingHistoryErrorInfos.Where(ex => ex.PackingID == cartonID);
        }
    }
}
