using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LogBLL
    {
        LogDAO dao = new LogDAO();

        public static void AddLog(int processType, string tableName, int processID)
        {
            LogDAO.AddLog(processType, tableName, processID);
        }

        public List<LogDTO> GetLogs()
        {
            return dao.GetLogs();
        }
    }
}
