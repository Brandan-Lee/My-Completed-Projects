using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GeneralDAO : PostContext
    {
        public List<VideoDTO> GetAllVideos()
        {
            List<VideoDTO> dtoList = new List<VideoDTO>();
            List<Video> list = db.Videos.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();

            foreach (var item in list)
            {
                VideoDTO dto = new VideoDTO();

                dto.ID = item.ID;
                dto.Title = item.Title;
                dto.VideoPath = item.VideoPath;
                dto.OriginalVideoPath = item.OriginalVideoPath;
                dto.AddDate = item.AddDate;

                dtoList.Add(dto);
            }

            return dtoList;
        }

        public List<PostDTO> GetBreakingPosts()
        {
            List<PostDTO> dtoList = new List<PostDTO>();

            var list = (from p in db.Posts.Where(x => x.Slider == false && x.isDeleted == false)
                        join c in db.Categories on p.CategoryID equals c.ID
                        select new
                        {
                            PostID = p.ID,
                            Title = p.Title,
                            CategoryName = c.CategoryName,
                            SeoLink = p.SeoLink,
                            ViewCount = p.ViewCount,
                            AddDate = p.AddDate,
                        }).OrderByDescending(x => x.AddDate).Take(5).ToList();

            foreach (var item in list)
            {
                PostDTO dto = new PostDTO();

                dto.ID = item.PostID;
                dto.Title = item.Title;
                dto.CategoryName = item.CategoryName;
                dto.ViewCount = item.ViewCount;
                dto.SeoLink = item.SeoLink;

                PostImage image = db.PostImages.First(x => x.isDeleted == false && x.PostID == item.PostID);
                dto.ImagePath = image.ImagePath;

                dto.CommentCount = db.Comments.Where(x => x.isDeleted == false && x.PostID == item.PostID && x.isApproved == true).Count();
                dto.AddDate = item.AddDate;

                dtoList.Add(dto);
            }

            return dtoList;
        }

        public List<PostDTO> GetCategoryPostList(int categoryID)
        {
            List<PostDTO> dtoList = new List<PostDTO>();

            var list = (from p in db.Posts.Where(x => x.isDeleted == false && x.CategoryID == categoryID)
                        join c in db.Categories on p.CategoryID equals c.ID
                        select new
                        {
                            PostID = p.ID,
                            Title = p.Title,
                            CategoryName = c.CategoryName,
                            SeoLink = p.SeoLink,
                            ViewCount = p.ViewCount,
                            AddDate = p.AddDate,
                        }).OrderByDescending(x => x.AddDate).ToList();

            foreach (var item in list)
            {
                PostDTO dto = new PostDTO();

                dto.ID = item.PostID;
                dto.Title = item.Title;
                dto.CategoryName = item.CategoryName;
                dto.ViewCount = item.ViewCount;
                dto.SeoLink = item.SeoLink;

                PostImage image = db.PostImages.First(x => x.isDeleted == false && x.PostID == item.PostID);
                dto.ImagePath = image.ImagePath;

                dto.CommentCount = db.Comments.Where(x => x.isDeleted == false && x.PostID == item.PostID && x.isApproved == true).Count();
                dto.AddDate = item.AddDate;

                dtoList.Add(dto);
            }

            return dtoList;
        }

        public List<PostDTO> GetMostViewedPosts()
        {
            List<PostDTO> dtoList = new List<PostDTO>();

            var list = (from p in db.Posts.Where(x => x.isDeleted == false)
                        join c in db.Categories on p.CategoryID equals c.ID
                        select new
                        {
                            PostID = p.ID,
                            Title = p.Title,
                            CategoryName = c.CategoryName,
                            SeoLink = p.SeoLink,
                            ViewCount = p.ViewCount,
                            AddDate = p.AddDate,
                        }).OrderByDescending(x => x.ViewCount).Take(5).ToList();

            foreach (var item in list)
            {
                PostDTO dto = new PostDTO();

                dto.ID = item.PostID;
                dto.Title = item.Title;
                dto.CategoryName = item.CategoryName;
                dto.ViewCount = item.ViewCount;
                dto.SeoLink = item.SeoLink;

                PostImage image = db.PostImages.First(x => x.isDeleted == false && x.PostID == item.PostID);
                dto.ImagePath = image.ImagePath;

                dto.CommentCount = db.Comments.Where(x => x.isDeleted == false && x.PostID == item.PostID && x.isApproved == true).Count();
                dto.AddDate = item.AddDate;

                dtoList.Add(dto);
            }

            return dtoList;
        }

        public List<PostDTO> GetPopularPosts()
        {
            List<PostDTO> dtoList = new List<PostDTO>();

            var list = (from p in db.Posts.Where(x => x.isDeleted == false && x.Area2 == true)
                        join c in db.Categories on p.CategoryID equals c.ID
                        select new
                        {
                            PostID = p.ID,
                            Title = p.Title,
                            CategoryName = c.CategoryName,
                            SeoLink = p.SeoLink,
                            ViewCount = p.ViewCount,
                            AddDate = p.AddDate,
                        }).OrderByDescending(x => x.AddDate).Take(5).ToList();

            foreach (var item in list)
            {
                PostDTO dto = new PostDTO();

                dto.ID = item.PostID;
                dto.Title = item.Title;
                dto.CategoryName = item.CategoryName;
                dto.ViewCount = item.ViewCount;
                dto.SeoLink = item.SeoLink;

                PostImage image = db.PostImages.First(x => x.isDeleted == false && x.PostID == item.PostID);
                dto.ImagePath = image.ImagePath;

                dto.CommentCount = db.Comments.Where(x => x.isDeleted == false && x.PostID == item.PostID && x.isApproved == true).Count();
                dto.AddDate = item.AddDate;

                dtoList.Add(dto);
            }

            return dtoList;
        }

        public PostDTO GetPostDetail(int ID)
        {
            Post post = db.Posts.First(x => x.ID == ID);
            //Increment the viewcount
            post.ViewCount++;
            db.SaveChanges();

            PostDTO dto = new PostDTO();
            dto.ID = post.ID;
            dto.Title = post.Title;
            dto.ShortContent = post.ShortContent;
            dto.PostContent = post.PostContent;
            dto.Language = post.LanguageName;
            dto.SeoLink = post.SeoLink;
            dto.CategoryID = post.CategoryID;
            dto.CategoryName = (db.Categories.First(x => x.ID == dto.CategoryID)).CategoryName;
            dto.ViewCount = post.ViewCount;

            List<PostImage> images = db.PostImages.Where(x => x.isDeleted == false && x.PostID == ID).ToList();
            List<PostImageDTO> imageDtoList = new List<PostImageDTO>();

            foreach (var item in images)
            {
                PostImageDTO img = new PostImageDTO();

                img.ID = item.ID;
                img.ImagePath = item.ImagePath;

                imageDtoList.Add(img);
            }

            dto.PostImages = imageDtoList;
            dto.CommentCount = db.Comments.Where(x => x.isDeleted == false && x.PostID == ID && x.isApproved == true).Count();

            List<Comment> comments = db.Comments.Where(x => x.isDeleted == false && x.PostID == ID && x.isApproved == true).ToList();
            List<CommentDTO> commentdtolist = new List<CommentDTO>();

            foreach (var item in comments)
            {
                CommentDTO cdto = new CommentDTO();

                cdto.ID = item.ID;
                cdto.AddDate = item.AddDate;
                cdto.CommentContent = item.CommentContent;
                cdto.Name = item.NameSurname;
                cdto.Email = item.Email;

                commentdtolist.Add(cdto);
            }
            
            dto.CommentList = commentdtolist;

            List<PostTag> tags = db.PostTags.Where(x => x.isDeleted == false && x.PostID == ID).ToList();
            List<PostTagDTO> taglist = new List<PostTagDTO>();

            foreach (var item in tags)
            {
                PostTagDTO tdto = new PostTagDTO();

                tdto.ID = item.ID;
                tdto.TagContent = item.TagContent;

                taglist.Add(tdto);
            }

            dto.TagList = taglist;

            return dto;
        }

        public List<PostDTO> GetSearchPosts(string searchText)
        {
            List<PostDTO> dtoList = new List<PostDTO>();

            var list = (from p in db.Posts.Where(x => x.isDeleted == false && (x.Title.Contains(searchText) || x.PostContent.Contains(searchText)))
                        join c in db.Categories on p.CategoryID equals c.ID
                        select new
                        {
                            PostID = p.ID,
                            Title = p.Title,
                            CategoryName = c.CategoryName,
                            SeoLink = p.SeoLink,
                            ViewCount = p.ViewCount,
                            AddDate = p.AddDate,
                        }).OrderByDescending(x => x.AddDate).ToList();

            foreach (var item in list)
            {
                PostDTO dto = new PostDTO();

                dto.ID = item.PostID;
                dto.Title = item.Title;
                dto.CategoryName = item.CategoryName;
                dto.ViewCount = item.ViewCount;
                dto.SeoLink = item.SeoLink;

                PostImage image = db.PostImages.First(x => x.isDeleted == false && x.PostID == item.PostID);
                dto.ImagePath = image.ImagePath;

                dto.CommentCount = db.Comments.Where(x => x.isDeleted == false && x.PostID == item.PostID && x.isApproved == true).Count();
                dto.AddDate = item.AddDate;

                dtoList.Add(dto);
            }

            return dtoList;
        }

        public List<PostDTO> GetSliderPosts()
        {
            List<PostDTO> dtoList = new List<PostDTO>();

            var list = (from p in db.Posts.Where(x => x.Slider == true && x.isDeleted == false)
                        join c in db.Categories on p.CategoryID equals c.ID
                        select new 
                        {
                            PostID = p.ID,
                            Title = p.Title,
                            CategoryName = c.CategoryName,
                            SeoLink = p.SeoLink,
                            ViewCount = p.ViewCount,
                            AddDate = p.AddDate,
                        }).OrderByDescending(x => x.AddDate).Take(8).ToList();

            foreach (var item in list)
            {
                PostDTO dto = new PostDTO();

                dto.ID = item.PostID;
                dto.Title = item.Title;
                dto.CategoryName = item.CategoryName;
                dto.ViewCount = item.ViewCount;
                dto.SeoLink = item.SeoLink;

                PostImage image = db.PostImages.First(x => x.isDeleted == false && x.PostID == item.PostID);
                dto.ImagePath = image.ImagePath;

                dto.CommentCount = db.Comments.Where(x => x.isDeleted == false && x.PostID == item.PostID && x.isApproved == true).Count();
                dto.AddDate = item.AddDate;

                dtoList.Add(dto);
            }

            return dtoList;
        }

        public List<VideoDTO> GetVideos()
        {
            List<VideoDTO> dtoList = new List<VideoDTO>();
            List<Video> list = db.Videos.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).Take(3).ToList();

            foreach (var item in list)
            {
                VideoDTO dto = new VideoDTO();

                dto.ID = item.ID;
                dto.Title = item.Title;
                dto.VideoPath = item.VideoPath;
                dto.OriginalVideoPath = item.OriginalVideoPath;
                dto.AddDate = item.AddDate;

                dtoList.Add(dto);
            }

            return dtoList;
        }
    }
}
