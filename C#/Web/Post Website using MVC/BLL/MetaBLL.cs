using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MetaBLL
    {
        MetaDAO dao = new MetaDAO();

        public bool AddMeta(MetaDTO model)
        {
            Meta meta = new Meta();

            meta.Name = model.Name;
            meta.MetaContent = model.MetaContent;
            meta.AddDate = DateTime.Now;
            meta.LastUpdateUserID = UserStatic.UserID;
            meta.LastUpdateDate = DateTime.Now;

            int metaID = dao.AddMeta(meta);
            LogDAO.AddLog(General.ProcessType.MetaAdd, General.TableName.Meta, metaID);
            return true;
        }

        public void DeleteMeta(int ID)
        {
            dao.DeleteMeta(ID);
            LogDAO.AddLog(General.ProcessType.MetaDelete, General.TableName.Meta, ID);
        }

        public List<MetaDTO> GetMetaData()
        {
            List<MetaDTO> dtoList = new List<MetaDTO>();
            dtoList = dao.GetMetaData();
            return dtoList;
        }

        public MetaDTO GetMetaWithID(int ID)
        {
            MetaDTO dto = new MetaDTO();
            dto = dao.GetMetaWithID(ID);
            return dto;
        }

        public bool UpdateMeta(MetaDTO model)
        {
            dao.UpdateMeta(model);
            LogDAO.AddLog(General.ProcessType.MetaUpdate, General.TableName.Meta, model.MetaID);
            return true;
        }
    }
}
