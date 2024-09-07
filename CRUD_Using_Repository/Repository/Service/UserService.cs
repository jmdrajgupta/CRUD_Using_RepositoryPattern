using CRUD_Using_Repository.Data; // Importing the ApplicationContext for database access
using CRUD_Using_Repository.Models; // Importing the User model
using CRUD_Using_Repository.Repository.Interface; // Importing the IUser interface
using Microsoft.EntityFrameworkCore; // Importing EF Core for async operations

namespace CRUD_Using_Repository.Repository.Service
{
    // UserService: This class implements the IUser interface and contains logic to interact with the database using Entity Framework Core.
    public class UserService : IUser
    {
        // ApplicationContext: This is the EF Core database context used to interact with the database.
        private readonly ApplicationContext context;

        // Constructor that injects the database context into the service.
        public UserService(ApplicationContext context)
        {
            this.context = context; // Initialize the context for database operations
        }

        // GetUsers: Asynchronously retrieves all users from the database as a list.
        public async Task<IEnumerable<User>> GetUsers()
        {
            var data = await context.Users.ToListAsync(); // Retrieve all users and convert to a list
            return data; // Return the list of users
        }

        // AddUser: Asynchronously adds a new user to the database.
        public async Task<int> AddUser(User user)
        {
            await context.Users.AddAsync(user); // Add the user to the database
            await context.SaveChangesAsync(); // Save the changes asynchronously
            return user.UserId; // Return the newly generated user ID
        }

        // GetUserById: Asynchronously retrieves a user by their ID.
        public async Task<User> GetUserById(int id)
        {
            var data = await context.Users.Where(e => e.UserId == id).FirstOrDefaultAsync(); // Find the user by ID
            return data; // Return the user object (or null if not found)
        }

        // UpdateRecord: Asynchronously updates an existing user record in the database.
        public async Task<bool> UpdateRecord(User user)
        {
            bool status = false; // Flag to indicate if the update was successful
            if (user != null)
            {
                context.Users.Update(user); // Update the user record
                await context.SaveChangesAsync(); // Save the changes asynchronously
                status = true; // Set status to true if update was successful
            }
            return status; // Return whether the update succeeded or not
        }

        // UpdateUser: Not implemented yet.
        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException(); // Throws an exception because it's not implemented
        }

        // Synchronous UpdateRecord: This method is not implemented yet.
        bool IUser.UpdateRecord(User user)
        {
            throw new NotImplementedException(); // Throws an exception because it's not implemented
        }

        // DeleteRecord: Asynchronously deletes a user record from the database by their ID.
        public async Task<bool> DeleteRecord(int id)
        {
            bool status = false; // Flag to indicate if the deletion was successful
            if (id != 0)
            {
                var data = await context.Users.Where(e => e.UserId == id).FirstOrDefaultAsync(); // Find the user by ID
                if (data != null)
                {
                    context.Users.Remove(data); // Remove the user from the database
                    await context.SaveChangesAsync(); // Save the changes asynchronously
                    status = true; // Set status to true if deletion was successful
                }
            }
            return status; // Return whether the deletion succeeded or not
        }
    }
}
