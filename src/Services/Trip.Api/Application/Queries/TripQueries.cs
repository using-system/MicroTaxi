namespace Trip.Api.Application.Queries
{
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    using Dapper;

    /// <summary>
    /// Trip queries implementation class
    /// </summary>
    /// <seealso cref="Trip.Api.Application.Queries.ITripQueries" />
    public class TripQueries : ITripQueries
    {
        private string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="TripQueries" /> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public TripQueries(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets the trip asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<Model.Trip> GetTripAsync(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                return await connection.QueryFirstAsync<Model.Trip>(@"SELECT [Id] as TripID, [PassengerId] as PassengerID
                    FROM [Trip].[Trips]
                    WHERE Id = @id", new { id });
            }
        }
    }
}
