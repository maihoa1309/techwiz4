using Microsoft.AspNetCore.Mvc;

namespace StreamTrace.Controllers
{
    public class UploadFileController : Controller
    {
        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            // Check if a file was actually uploaded
            if (file == null || file.Length == 0)
            {
                // Handle the case when no file was selected for upload
                // Redirect to an appropriate action or return an error message
                return RedirectToAction("Error");
            }

            // Get the file name and extension
            var fileName = Path.GetFileName(file.FileName);
            var fileExtension = Path.GetExtension(file.FileName);

            // Generate a unique file name to prevent conflicts
            var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;

            // Define the path where the file will be saved
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", uniqueFileName);

            // Save the file to the specified path
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // Optionally, you can perform additional operations with the uploaded file
            // For example, you can store information in a database or process the file's content

            // Redirect to a success page or return a success message
            return RedirectToAction("Success");
        }
       
    }
}
