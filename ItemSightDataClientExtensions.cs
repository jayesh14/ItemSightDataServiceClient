using System;
using System.Linq;
using ItemSightDataServiceClient.ItemSightDataService;

namespace ItemSightDataServiceClient {
    public static class ItemSightDataClientExtensions {
        public static IQueryable<PackingEx> WhereFactoryOrDcLocation(this IQueryable<PackingEx> cartons, int locationID) {
            return cartons.Where(ex => ex.Packing.bizLocationID == locationID);
        }

        public static IQueryable<PackingEx> WhereReadpointDevice(this IQueryable<PackingEx> cartons, int deviceID) {
            return cartons.Where(ex => ex.Packing.readPointID == deviceID);
        }

        public static IQueryable<PackingEx> WhereDateRange(this IQueryable<PackingEx> cartons, DateTime startDate, DateTime endDate) {
            var endDateExcl = endDate.AddDays(1);
            return cartons.Where(ex => ex.Packing.TimeStamp >= startDate && ex.Packing.TimeStamp < endDateExcl);
        }

        public static IQueryable<PackingEx> WhereRfidCarton(this IQueryable<PackingEx> cartons) {
            return cartons.Where(ex => ex.CanBeVerified);
        }

        public static IQueryable<PackingEx> WhereErrorsIssues(this IQueryable<PackingEx> cartons) {
            return cartons.Where(ex => ex.HasOrHadErrors);
        }

    }
}