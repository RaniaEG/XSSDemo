using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MvcApp.Controllers
{
    public class ProtectedStoredController : Controller
    {
        private string CommentsFilePath = "wwwroot/data/comments.txt";

        [HttpGet]
        public IActionResult Index()
        {
            var comments = ReadCommentsFromFile();
            return View(comments);
        }




        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                SaveCommentToFile(comment);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        private List<Comment> ReadCommentsFromFile()
        {
            var comments = new List<Comment>();
            if (System.IO.File.Exists(CommentsFilePath))
            {
                var lines = System.IO.File.ReadAllLines(CommentsFilePath, Encoding.UTF8);
                foreach (var line in lines)
                {
                    var parts = line.Split("||");
                    if (parts.Length == 2)
                    {
                        comments.Add(new Comment { Username = parts[0], Text = parts[1] });
                    }
                }
            }
            return comments;
        }

        private void SaveCommentToFile(Comment comment)
        {
            var serializedComment = $"{comment.Username}||{comment.Text}";
            System.IO.File.AppendAllText(CommentsFilePath, serializedComment + "\n", Encoding.UTF8);
        }
    }
}
