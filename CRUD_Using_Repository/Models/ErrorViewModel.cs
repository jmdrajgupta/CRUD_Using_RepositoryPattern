namespace CRUD_Using_Repository.Models
{
    // ErrorViewModel: This model is used to represent error information to be displayed in an error view.
    public class ErrorViewModel
    {
        // RequestId: This property holds the unique ID of the current HTTP request. It is used for tracking and debugging purposes.
        // The '?' after string indicates that this property is nullable, meaning it can hold either a string value or be null.
        public string? RequestId { get; set; }

        // ShowRequestId: This is a derived property (a read-only property) that returns true if the RequestId is not null or empty.
        // It's used to determine whether the RequestId should be shown in the error view.
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
