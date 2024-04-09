namespace HttpServices
{
    public class BeerService : BaseService
    {
        public static async Task<Beer> GetByIdAsync(int id)
        {
            Beer beer = await SendGetRequestAsync<Beer>("api/beer/get", id);
            return beer;
        }

        public static async Task<List<Beer>> GetAllAsync()
        {
			List<Beer> beers = await SendGetRequestAsync<List<Beer>>("api/beer/getall");
			return beers;
		}

        public static bool DeleteById(int id)
        {
            try
            {
				SendDeleteRequestAsync("api/beer/delete", id);
                return true;

			} catch (Exception e)
            {
				return false;
			}
        }
    }
}
