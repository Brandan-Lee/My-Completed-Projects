using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL
{
    public class LogDAO : PostContext
    {
        public static void AddLog(int processType, string tableName, int processID)
        {
            Log_Table log = new Log_Table();

            log.UserID = UserStatic.UserID;
            log.ProcessType = processType;
            log.ProcessID = processID;
            log.ProcessCategoryType = tableName;
            log.ProcessDate = DateTime.Now;
            log.IPAddress = HttpContext.Current.Request.UserHostAddress;

            db.Log_Table.Add(log);
            db.SaveChanges();
        }

        public List<LogDTO> GetLogs()
        {
            List<LogDTO> dtoList = new List<LogDTO>();

            var list = (from l in db.Log_Table
                        join u in db.T_User on l.UserID equals u.ID
                        join p in db.ProcessTypes on l.ProcessType equals p.ID
                        select new 
                        {
                            ID = l.ID,
                            Username = u.Username,
                            TableName = l.ProcessCategoryType,
                            TableID = l.ProcessID,
                            ProcessName = p.ProcessName,
                            ProcessDate = l.ProcessDate,
                            IpAddress = l.IPAddress
                        }).OrderByDescending(x => x.ProcessDate).ToList();

            foreach (var item in list)
            {
                LogDTO dto = new LogDTO();

                dto.ID = item.ID;
                dto.UserName = item.Username;
                dto.TableName = item.TableName;
                dto.TableID = item.TableID;
                dto.ProcessName = item.ProcessName;
                dto.ProcessDate = item.ProcessDate;
                dto.IPAddress = item.IpAddress;

                dtoList.Add(dto);
            }

            return dtoList;
        }
    }
}
