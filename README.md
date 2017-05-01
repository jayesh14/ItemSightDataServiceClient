# ItemSightDataServiceClient
Query wrapper using client data service classes for ItemSight Data Service.

## Usage

	var svcClient = new ItemSightDataClient({urlString});
	svcClient.GetCartons() ... etc.

All methods return `IQueryable<T>`.

