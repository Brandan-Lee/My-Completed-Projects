using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL
{
    public class CategoryBLL
    {
        PostBLL postBLL = new PostBLL();

        CategoryDAO dao = new CategoryDAO();

        public static IEnumerable<SelectListItem> GetCategoriesForDropDown()
        {
            return CategoryDAO.GetCategoriesForDropDown();
        }

        public bool AddCategory(CategoryDTO model)
        {
            Category category = new Category();

            category.CategoryName = model.CategoryName;
            category.AddDate = DateTime.Now;
            category.LastUpdateUserID = UserStatic.UserID;
            category.LastUpdateDate = DateTime.Now;

            int ID = dao.AddCategory(category);
            LogDAO.AddLog(General.ProcessType.CategoryAdd, General.TableName.Category, ID);
            return true;
        }

        public List<PostImageDTO> DeleteCategory(int ID)
        {
            List<Post> postList = dao.DeleteCategory(ID);
            LogDAO.AddLog(General.ProcessType.CategoryDelete, General.TableName.Category, ID);
            List<PostImageDTO> imageList = new List<PostImageDTO>();

            foreach (var item in postList)
            {
                List<PostImageDTO> imageList2 = postBLL.DeletePost(item.ID);
                LogDAO.AddLog(General.ProcessType.PostDelete, General.TableName.Post, item.ID);

                foreach (var item2 in imageList2)
                {
                    imageList.Add(item2);
                }
            }

            return imageList;
        }

        public List<CategoryDTO> GetCategories()
        {
            return dao.GetCategories();
        }

        public CategoryDTO GetCategoryWithID(int ID)
        {
            return dao.GetCategoryWithID(ID);
        }

        public bool UpdateCategory(CategoryDTO model)
        {
            dao.UpdateCategory(model);
            LogDAO.AddLog(General.ProcessType.CategoryUpdate, General.TableName.Category, model.ID);
            return true;
        }
    }
}
