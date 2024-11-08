using hw1_ef_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hw1_ef_core.Services
{
    class Service
    {
        public AppDbContext Context { get; set; }
        public Service(AppDbContext context) 
        { 
            Context = context;
        }
        public void CreateTask(hw1_ef_core.Models.Task task)
        {
            Context.Tasks.Add(task);
            Context.SaveChanges();
        }
        public void DeleteTask(int id)
        {
            var taskToDelete = Context.Tasks.Find(id);
            if (taskToDelete != null)
            {
                Context.Tasks.Remove(taskToDelete);
                Context.SaveChanges();
            }
        }
        public IEnumerable<hw1_ef_core.Models.Task> ReadTasks()
        {
            return Context.Tasks;
        }
        public void UpdateTask(int id, hw1_ef_core.Models.Task task)
        {
            var taskToUpdate = Context.Tasks.Find(id);
            if (taskToUpdate != null)
            {
                taskToUpdate.Description = task.Description;
                taskToUpdate.Name = task.Name;
                taskToUpdate.CreateDate = task.CreateDate;
                taskToUpdate.IsCompleted = task.IsCompleted;
            }
        }
        public hw1_ef_core.Models.Task FindTaskById(int id)
        {
            var task = Context.Tasks.Find(id);
            return task;
        }

        public void CreateCategory(hw1_ef_core.Models.Category task)
        {
            Context.Categories.Add(task);
            Context.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            var categoryToDelete = Context.Categories.Find(id);
            if (categoryToDelete != null)
            {
                Context.Categories.Remove(categoryToDelete);
                Context.SaveChanges();
            }
        }
        public IEnumerable<hw1_ef_core.Models.Category> ReadCategory()
        {
            return Context.Categories;
        }
        public void UpdateCategory(int id, hw1_ef_core.Models.Category category)
        {
            var categoryToUpdate = Context.Categories.Find(id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }
        public hw1_ef_core.Models.Category FindCategoryById(int id)
        {
            var category = Context.Categories.Find(id);
            return category;
        }
    }
}
