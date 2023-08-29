using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LayoutBLL
    {
        CategoryDAO categorydao = new CategoryDAO();
        SocialMediaDAO socialdao = new SocialMediaDAO();
        FavDAO favdao = new FavDAO();
        MetaDAO metadao = new MetaDAO();
        AddressDAO addressdao = new AddressDAO();
        PostDAO postdao = new PostDAO();

        public HomeLayoutDTO GetLayoutData()
        {
            HomeLayoutDTO dto = new HomeLayoutDTO();
            dto.Categories = categorydao.GetCategories();
            List<SocialMediaDTO> socialMediaList = new List<SocialMediaDTO>();
            socialMediaList = socialdao.GetSocialMedias();
            dto.Facebook = socialMediaList.First(x => x.Link.Contains("facebook"));
            dto.Twitter = socialMediaList.First(x => x.Link.Contains("twitter"));
            dto.Instagram = socialMediaList.First(x => x.Link.Contains("instagram"));
            dto.Youtube = socialMediaList.First(x => x.Link.Contains("youtube"));
            dto.LinkedIn = socialMediaList.First(x => x.Link.Contains("linkedin"));
            dto.FavDTO = favdao.GetFav();
            dto.MetaList = metadao.GetMetaData();
            List<AddressDTO> addressList = addressdao.GetAddresses();
            dto.Address = addressList.First();
            dto.HotNews = postdao.GetHotNews();
            

            return dto;
        }
    }
}
