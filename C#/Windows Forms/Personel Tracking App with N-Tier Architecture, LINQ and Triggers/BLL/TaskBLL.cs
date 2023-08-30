using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
using DAL;

namespace BLL
{
    public class TaskBLL
    {
        public static void AddTask(TASK task)
        {
            TaskDAO.AddTask(task);
        }

        public static void ApproveTask(int taskID, bool isAdmin)
        {
            TaskDAO.ApproveTask(taskID, isAdmin);
        }

        public static void DeleteTask(int taskID)
        {
            TaskDAO.DeleteTask(taskID);
        }

        public static TaskDTO GetAll()
        {
            TaskDTO taskDto = new TaskDTO();

            taskDto.Employees = EmployeeDAO.GetEmployees();
            taskDto.Departments = DepartmentDAO.GetDepartments();
            taskDto.Positions = PositionDAO.GetPositions();
            taskDto.TaskStates = TaskDAO.GetTaskStates();
            taskDto.Tasks = TaskDAO.GetTasks();

            return taskDto;
        }

        public static void UpdateTask(TASK task)
        {
            TaskDAO.UpdateTask(task);
        }
    }
}
