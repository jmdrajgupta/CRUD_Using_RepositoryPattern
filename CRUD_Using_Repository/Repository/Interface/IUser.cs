using CRUD_Using_Repository.Models; // Import the User model to define methods related to user management

namespace CRUD_Using_Repository.Repository.Interface
{
    // IUser interface: Defines the contract for user-related operations (CRUD) that must be implemented by any repository class.
    public interface IUser
    {
        // GetUsers: Asynchronously retrieves a collection of all users. The return type is a Task of IEnumerable<User>, which represents a list of users.
        Task<IEnumerable<User>> GetUsers(); // Retrieves all users

        // AddUser: Asynchronously adds a new user to the database. The method takes a User object as input and returns an int indicating the ID of the new user.
        Task<int> AddUser(User user); // Adds a user and returns the ID

        // GetUserById: Asynchronously retrieves a user by their ID. It takes an integer ID as a parameter and returns a User object.
        Task<User> GetUserById(int id); // Retrieves a user by ID

        // UpdateUser: Asynchronously updates an existing user in the database. It takes a User object and returns a boolean indicating success or failure.
        Task<bool> UpdateUser(User user); // Updates an existing user

        // UpdateRecord: Updates an existing user synchronously (without async). Takes a User object and returns a boolean indicating success or failure.
        bool UpdateRecord(User user); // Updates an existing user (non-async)

        // DeleteRecord: Asynchronously deletes a user by their ID. It returns a boolean indicating whether the deletion was successful.
        Task<bool> DeleteRecord(int id); // Deletes a user by ID
    }
}
