using CRUD_Using_Repository.Models;               // Importing the namespace to access the User model and possibly other models
using CRUD_Using_Repository.Repository.Interface; // Importing the IUser interface, which defines the methods for CRUD operations
using Microsoft.AspNetCore.Mvc;                   // Importing ASP.NET Core MVC library for controller functionality

namespace CRUD_Using_Repository.Controllers
{
    // UserController: This class handles all user-related actions, such as listing users, adding, editing, and deleting them.
    public class UserController : Controller
    {
        private readonly IUser userRepository; // Dependency injection of the IUser repository interface for performing operations

        // Constructor: Injects the user repository interface to use its methods in the controller
        public UserController(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        // GetUserList Action: Retrieves the list of users asynchronously from the repository and passes the data to the view.
        public async Task<IActionResult> GetUserList()
        {
            var data = await userRepository.GetUsers(); // Get the list of users from the repository
            return View(data);                          // Pass the data to the view to display the user list
        }

        // AddUser (GET): Displays the view for adding a new user.
        public async Task<IActionResult> AddUser()
        {
            return View(); // Return the view to show the form for adding a user
        }

        // AddUser (POST): Handles the form submission for adding a new user. Takes the User object from the form.
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                // Check if the model is valid
                if (!ModelState.IsValid)
                {
                    return View(user); // If the model is invalid, return the view with the user data for correction
                }
                else
                {
                    await userRepository.AddUser(user); // Call the repository method to add the user to the database

                    // Check if the user was successfully saved
                    if (user.UserId == 0)
                    {
                        TempData["userError"] = "Record not Saved"; // Display error message if the save failed
                    }
                    else
                    {
                        TempData["userSuccess"] = "Record successfully saved"; // Display success message if the save succeeded
                    }
                }
            }
            catch (Exception)
            {
                throw; // Re-throw the exception for handling elsewhere (logging, etc.)
            }

            // Redirect to the GetUserList action after saving the user
            return RedirectToAction("GetUserList");
        }

        // Edit (GET): Retrieves the user data for the specified ID and displays the edit form.
        public async Task<IActionResult> Edit(int id)
        {
            User user = new User(); // Create a new User object

            try
            {
                // If the ID is invalid (0), return a BadRequest response
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    user = await userRepository.GetUserById(id); // Retrieve the user by ID from the repository

                    // If the user is not found, return a NotFound response
                    if (user == null)
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception)
            {
                throw; // Re-throw the exception for further handling
            }

            return View(user); // Pass the user data to the view for editing
        }

        // Edit (POST): Handles the form submission for editing a user.
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            try
            {
                // If the model is invalid, return the view with the user data for correction
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                else
                {
                    bool status = userRepository.UpdateRecord(user); // Call the repository method to update the user record

                    // Set TempData based on whether the update succeeded or not
                    if (status)
                    {
                        TempData["userSuccess"] = "Your record has been successfully updated";
                    }
                    else
                    {
                        TempData["userError"] = "Your record has not been updated";
                    }
                }
            }
            catch (Exception)
            {
                throw; // Re-throw the exception for further handling
            }

            // Redirect to the GetUserList action after updating the user
            return RedirectToAction("GetUserList");
        }

        // DeleteRecord: Deletes a user by the specified ID.
        public async Task<IActionResult> DeleteRecord(int id)
        {
            try
            {
                // If the ID is invalid (0), return a BadRequest response
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    bool status = await userRepository.DeleteRecord(id); // Call the repository method to delete the user

                    // Set TempData based on whether the deletion succeeded or not
                    if (status)
                    {
                        TempData["userSuccess"] = "Record has been successfully deleted";
                    }
                    else
                    {
                        TempData["userError"] = "Record not deleted";
                    }
                }
            }
            catch (Exception)
            {
                throw; // Re-throw the exception for further handling
            }

            // Redirect to the GetUserList action after deleting the user
            return RedirectToAction("GetUserList");
        }
    }
}
